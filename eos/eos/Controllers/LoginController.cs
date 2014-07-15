using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using eos.Models;
using eos.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace eos.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        #region Data

        private UserManager _userManager;

        public UserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
            private set { _userManager = value; }
        }

        public String CurrentUserId
        {
            get { return User.Identity.GetUserId(); }
        }

        #endregion

        #region Constructors

        public LoginController()
        {
        }

        public LoginController(UserManager userManager)
        {
            UserManager = userManager;
        }

        #endregion

        #region Login

        #region GET: /Login

        // GET: /Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region POST: /Login

        // POST: /Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {
                var user = await UserManager.Instance.FindAsync(model.Email, model.Password);

                if (user != null) {
                    await UserManager.Instance.Login(user, true);

                    return View("../Verse/Index");
                }

                ModelState.AddModelError("", "Invalid email or password.");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #endregion

        #endregion

        #region Register

        #region GET: /Login/Register

        // GET: /Login/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        #endregion

        #region POST: /Login/Register

        // POST: /Login/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                var user = new User { UserName = model.Email, Email = model.Email };
                var result = UserManager.Instance.Create(user, model.Password);
                if (result.Succeeded) {
                    await UserManager.Instance.Login(user);

                    // For more information on how to enable Login confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Login", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your Login", "Please confirm your Login by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Verse");
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error);
                }
            }

            return View();
        }

        #endregion

        #endregion

        #region External Login

        //
        // POST: /Login/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Login", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Login/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await HttpContext.GetOwinContext().Authentication.GetExternalLoginInfoAsync();

            if (loginInfo == null) {
                return RedirectToAction("Index", "Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var user = await UserManager.Instance.FindAsync(loginInfo.Login);

            if (user != null) {
                await UserManager.Instance.Login(user);

                return RedirectToLocal(returnUrl);
            }

            // If the user does not have an Login, then prompt the user to create an Login
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;

            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        }

        //
        // POST: /Login/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Login"), User.Identity.GetUserId());
        }

        #endregion

        #region Link Login Callback

        //
        // GET: /Login/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await HttpContext.GetOwinContext()
                        .Authentication.GetExternalLoginInfoAsync(ConfigurationManager.AppSettings["XsrfKey"],
                            User.Identity.GetUserId());

            if (loginInfo == null) {
                return RedirectToAction("Index", "Login", new { Message = ManageMessageId.Error });
            }

            var result = await UserManager.Instance.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);

            return result.Succeeded ? RedirectToAction("Index", "Login") : RedirectToAction("Index", "Login", new { Message = ManageMessageId.Error });
        }

        //
        // POST: /Login/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid) {
                // Get the information about the user from the external login provider
                var info = await HttpContext.GetOwinContext().Authentication.GetExternalLoginInfoAsync();

                if (info == null) {
                    return View("ExternalLoginFailure");
                }

                var user = new User { UserName = model.Email, Email = model.Email };

                var result = await UserManager.Instance.CreateAsync(user);

                if (result.Succeeded) {
                    result = await UserManager.Instance.AddLoginAsync(user.Id, info.Login);

                    if (result.Succeeded) {
                        await UserManager.Instance.Login(user);

                        // For more information on how to enable Login confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        // var callbackUrl = Url.Action("ConfirmEmail", "Login", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                        // SendEmail(user.Email, callbackUrl, "Confirm your Login", "Please confirm your Login by clicking this link");

                        return RedirectToLocal(returnUrl);
                    }
                }

                foreach (var error in result.Errors) {
                    ModelState.AddModelError("", error);
                }
            }

            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }

        //
        // GET: /Login/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        #endregion

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (returnUrl != null && Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Verse");
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        #endregion

        #region Logoff

        //
        // POST: /Login/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Login");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        #endregion

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid) {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id))) {
                    ModelState.AddModelError("", "The user either does not exist or is not confirmed.");
                    return View();
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (code == null) {
                return View("Error");
            }
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid) {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null) {
                    ModelState.AddModelError("", "No user found.");
                    return View();
                }
                var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                if (result.Succeeded) {
                    return RedirectToAction("ResetPasswordConfirmation", "Login");
                }

                AddErrors(result);
                return View();
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}