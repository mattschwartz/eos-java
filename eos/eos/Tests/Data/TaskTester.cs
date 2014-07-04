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
                    Name = "Test",
                    Comments = "Test",
                    Color = "Test",
                    Subject = manager.Context.Subjects.Find(1),
                    User = manager.Context.Users.Find(1)
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
                    || task.User != manager.Context.Users.Find(1)
                    || task.Subject != manager.Context.Subjects.Find(1)) {
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