using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eos.Models.Tasks;

namespace eos.Tests.Data
{
    [TestFixture]
    public class TaskTesters : TestBase
    {
        [Test]
        public void SaveAndDeleteTask()
        {
            using (var manager = new TaskManager()) {
                Task task = new Task {
                    Name = "Test",
                    Comments = "Test",
                    Color = "Test",
                    Subject = manager.Context.Subjects.First(),
                    User = manager.Context.Users.First()
                };

                task.Id = manager.Save(task);

                if (task.Id <= 0) {
                    Assert.Fail("Task failed to save and returned with an id of " + task.Id);
                }

                task = manager.GetById(task.Id);

                if (task == null) {
                    Assert.Fail("The task was not found in the database.");
                }

                if (task.Name != "Test" 
                    || task.Comments != "Test" 
                    || task.Color != "Test"
                    || task.UserId != 1
                    || task.SubjectId != 1) {
                        Assert.Fail("The task retrieved was not the task that was saved.");
                }

                manager.Delete(task.Id);

                if (manager.GetById(task.Id) != null) {
                    Assert.Fail("Deleted tag still exists in database.");
                }
            }
        }
    }
}