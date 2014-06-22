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
                    name = "Test",
                    comments = "Test",
                    color = "Test",
                    UserId = 1
                };

                task.id = manager.Save(task);

                if (task.id <= 0) {
                    Assert.Fail("Tag failed to save and returned with an id of " + task.id);
                }

                task = manager.GetById(task.id);

                if (task == null) {
                    Assert.Fail("The tag was not found in the database.");
                }

                if (task.name != "Test" || task.comments != "Test" || task.color != "Test") {
                    Assert.Fail("The tag retrieved was not the tag that was saved.");
                }

                manager.Delete(task.id);

                if (manager.GetById(task.id) != null) {
                    Assert.Fail("Deleted tag still exists in database.");
                }
            }
        }
    }
}