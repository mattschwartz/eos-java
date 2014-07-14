using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using eos.Models.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace eos.Models.Users
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store, DataContext context)
            : base(store)
        {
            Context = context;
        }

        public static DataContext Context { get; set; }

        public static UserManager Instance
        {
            get { return (new HttpContextWrapper(HttpContext.Current)).GetOwinContext().GetUserManager<UserManager>(); }
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserStore<User>(context.Get<DataContext>()), context.Get<DataContext>());

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null) {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public async Task<Boolean> Login(User user, bool isPersistent = false)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            HttpContext.Current.GetOwinContext()
                .Authentication.SignIn(new AuthenticationProperties { IsPersistent = isPersistent },
                    await user.GenerateUserIdentityAsync(Instance));

            return true;
        }

        public static User FindById(string id)
        {
            return Context.Users.Find(id);
        }

        public static User FindByApiKey(string key)
        {
            return Context.Users.FirstOrDefault(t => t.ApiKey == key);
        }
    }
}