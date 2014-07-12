using System.Linq;
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
                    User = manager.Context.Users.First(),
                    Data = bytes,
                    Subject = manager.Context.Subjects.First(),
                    Task = manager.Context.Tasks.First(),
                    CalendarEvent = manager.Context.CalendarEvents.First()
                };

                document.Id = manager.Save(document);
                document = manager.GetById(document.Id);

                if (document == null) {
                    Assert.Fail("The document was not found in the database.");
                }

                if (document.User != manager.Context.Users.First()
                    || document.FileName != "test"
                    || document.Extension != ".txt"
                    || document.Data != bytes
                    || document.Subject != manager.Context.Subjects.First()
                    || document.Task != manager.Context.Tasks.First()
                    || document.CalendarEvent != manager.Context.CalendarEvents.First()) {
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