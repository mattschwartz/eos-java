using System.Linq;
using NUnit.Framework;
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
                var task = new Task
                {
                    Title = "Test",
                    Comment = "Test",
                    Color = "Test",
                    Subject = manager.Context.Subjects.First(),
                    User = manager.Context.Users.First()
                };

                task.Id = manager.Save(task);
                task = manager.GetById(task.Id);

                if (task == null) {
                    Assert.Fail("The task was not found in the database.");
                }

                if (task.Title != "Test" 
                    || task.Comment != "Test" 
                    || task.Color != "Test"
                    || task.User != manager.Context.Users.First()
                    || task.Subject != manager.Context.Subjects.First()) {
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