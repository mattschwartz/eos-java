using System.Linq;
using NUnit.Framework;
using System;
using eos.Models.Subjects;

namespace eos.Tests.Data
{
    [TestFixture]
    public class SubjectTester : TestBase
    {
        [Test]
        public void SaveAndDeleteSubject()
        {
            using (var manager = new SubjectManager()) {
                var subject = new Subject
                {
                    User = manager.Context.Users.Find(1),
                    XPos = 1,
                    YPos = 1,
                    Color = "test",
                    Details = "test",
                    Radius = Decimal.One,
                    Title = "test"
                };

                subject.Id = manager.Save(subject);

                if (subject.Id <= 0) {
                    Assert.Fail("Subject failed to save and returned with an id of " + subject.Id);
                }

                subject = manager.GetById(subject.Id);

                if (subject == null) {
                    Assert.Fail("The subject was not found in the database.");
                }

                if (subject.User != manager.Context.Users.Find(1)
                    || subject.XPos != 1
                    || subject.YPos != 1
                    || subject.Color != "test"
                    || subject.Details != "test"
                    || subject.Radius != Decimal.One
                    || subject.Title != "test") {
                        Assert.Fail("The subject retrieved was not the subject that was saved.");
                }

                manager.Delete(subject.Id);

                if (manager.GetById(subject.Id) != null) {
                    Assert.Fail("Deleted subject still exists in database.");
                }
            }
        }
    }
}