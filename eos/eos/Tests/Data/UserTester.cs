using NUnit.Framework;
using eos.Models.Users;

namespace eos.Tests.Data
{
    [TestFixture]
    public class UserTester : TestBase
    {
        [Test]
        public void SaveAndDeleteUser()
        {
            using (var manager = new UserManager()) {
                var user = new User {
                    Email = "test",
                    FirstName = "test",
                    LastName = "test",
                };

                user.Id = manager.Save(user);
                user = manager.GetById(user.Id);

                if (user == null) {
                    Assert.Fail("The user was not found in the database.");
                }

                if (user.Email != "test"
                    || user.FirstName != "test"
                    || user.LastName != "test") {
                        Assert.Fail("The user retrieved was not the user that was saved.");
                }

                manager.Delete(user.Id);

                if (manager.GetById(user.Id) != null) {
                    Assert.Fail("Deleted user still exists in database.");
                }
            }
        }
    }
}