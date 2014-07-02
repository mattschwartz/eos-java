using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eos.Models.Tasks;
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
                User user = new User {
                    Email = "test",
                    FirstName = "test",
                    LastName = "test",
                    Password = "test"
                };

                user.Id = manager.Save(user);

                if (user.Id <= 0) {
                    Assert.Fail("User failed to save and returned with an id of " + user.Id);
                }

                user = manager.GetById(user.Id);

                if (user == null) {
                    Assert.Fail("The user was not found in the database.");
                }

                if (user.Email != "test"
                    || user.FirstName != "test"
                    || user.LastName != "test"
                    || user.Password != "test") {
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