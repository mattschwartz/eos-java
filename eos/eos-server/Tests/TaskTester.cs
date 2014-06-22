using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eos.Models.Tasks;

namespace eos.Tests
{
    [TestFixture]
    public class TaskTesters : TestBase
    {
        [Test]
        public void SaveAndDelete()
        {
            using (var manager = new TaskManager()) {
                Task task = new Task {
                    Name = "Test",
                    Comments = "Test",
                    Color = "Test",
                    UserId = 1
                };

                task.Id = manager.Save(task);

                if (task.Id <= 0) {
                    Assert.Fail("Tag failed to save and returned with an id of " + task.Id);
                }

                task = manager.GetById(task.Id);

                if (task == null) {
                    Assert.Fail("The tag was not found in the database.");
                }

                if (task.Name != "Test" || task.Comments != "Test" || task.Color != "Test") {
                    Assert.Fail("The tag retrieved was not the tag that was saved.");
                }

                manager.Delete(task.Id);

                if (manager.GetById(task.Id) != null) {
                    Assert.Fail("Deleted tag still exists in database.");
                }
            }
        }
    }
}