using System;
using System.Linq;
using eos.Models.CalendarEvents;
using NUnit.Framework;

namespace eos.Tests.Data
{
    [TestFixture]
    public class CalendarEventTester : TestBase
    {
        [Test]
        public void SaveAndDeleteCalendarEvent()
        {
            using (var manager = new CalendarEventManager()) {
                var calendarEvent = new CalendarEvent
                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    Description = "test",
                    Title = "test",
                    User = manager.Context.Users.First(),
                    Subject = manager.Context.Subjects.First(),
                    Task = manager.Context.Tasks.First(),
                };

                calendarEvent.Id = manager.Save(calendarEvent);
                calendarEvent = manager.GetById(calendarEvent.Id);

                if (calendarEvent == null) {
                    Assert.Fail("The calendar event was not found in the database.");
                }

                if (calendarEvent.User != manager.Context.Users.First()
                    || calendarEvent.StartDate != DateTime.Today
                    || calendarEvent.EndDate != DateTime.Today.AddDays(1)
                    || calendarEvent.Title != "test"
                    || calendarEvent.Description != "test"
                    || calendarEvent.Subject != manager.Context.Subjects.First()
                    || calendarEvent.Task != manager.Context.Tasks.First()) {
                    Assert.Fail("The calendar event retrieved was not the calendar event that was saved.");
                }

                manager.Delete(calendarEvent.Id);

                if (manager.GetById(calendarEvent.Id) != null) {
                    Assert.Fail("Deleted calendar event still exists in database.");
                }
            }
        }
    }
}