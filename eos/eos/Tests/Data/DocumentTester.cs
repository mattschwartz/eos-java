using eos.Models.Documents;
using NUnit.Framework;

namespace eos.Tests.Data
{
    [TestFixture]
    public class DocumentTester : TestBase
    {
        [Test]
        public void SaveAndDeleteDocument()
        {
            using (var manager = new DocumentManager()) {
                var bytes = new byte[] {1, 2, 3};
                var document = new Document
                {
                    FileName = "test",
                    Extension = ".txt",
                    User = manager.Context.Users.Find(1),
                    Data = bytes,
                    Subject = manager.Context.Subjects.Find(1),
                    Task = manager.Context.Tasks.Find(1),
                    CalendarEvent = manager.Context.CalendarEvents.Find(1)
                };

                document.Id = manager.Save(document);

                if (document.Id <= 0) {
                    Assert.Fail("Document failed to save and returned with an id of " + document.Id);
                }

                document = manager.GetById(document.Id);

                if (document == null) {
                    Assert.Fail("The document was not found in the database.");
                }

                if (document.User != manager.Context.Users.Find(1)
                    || document.FileName != "test"
                    || document.Extension != ".txt"
                    || document.Data != bytes
                    || document.Subject != manager.Context.Subjects.Find(1)
                    || document.Task != manager.Context.Tasks.Find(1)
                    || document.CalendarEvent != manager.Context.CalendarEvents.Find(1)) {
                        Assert.Fail("The document retrieved was not the document that was saved.");
                }

                manager.Delete(document.Id);

                if (manager.GetById(document.Id) != null) {
                    Assert.Fail("Deleted document still exists in database.");
                }
            }
        }
    }
}