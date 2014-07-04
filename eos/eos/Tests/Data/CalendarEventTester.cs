using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eos.Models.Events;
using eos.Models.Users;
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
                var bytes = new byte[] { 1, 2, 3 };
                var calendarEvent = new CalendarEvent
                {
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(1),
                    Description = "test",
                    Title = "test",
                    User = manager.Context.Users.Find(1),
                    Subject = manager.Context.Subjects.Find(1),
                    Task = manager.Context.Tasks.Find(1),
                };

                calendarEvent.Id = manager.Save(calendarEvent);

                if (calendarEvent.Id <= 0) {
                    Assert.Fail("Calendar Event failed to save and returned with an id of " + calendarEvent.Id);
                }

                calendarEvent = manager.GetById(calendarEvent.Id);

                if (calendarEvent == null) {
                    Assert.Fail("The calendar event was not found in the database.");
                }

                if (calendarEvent.User != manager.Context.Users.Find(1)
                    || calendarEvent.StartDate != DateTime.Today
                    || calendarEvent.EndDate != DateTime.Today.AddDays(1)
                    || calendarEvent.Title != "test"
                    || calendarEvent.Description != "test"
                    || calendarEvent.Subject != manager.Context.Subjects.Find(1)
                    || calendarEvent.Task != manager.Context.Tasks.Find(1)) {
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