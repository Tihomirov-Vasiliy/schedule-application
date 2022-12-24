using ICalDomain.Models;
using ScheduleApplication.Model;
using System;
using System.Collections.Generic;

namespace ScheduleApplication.Services
{
    /// <summary>
    /// Represents service for creating content of ical file from lessons' list
    /// </summary>
    public static class IcalService
    {
        public static string GetStringOfIcalFile(List<Lesson> lessons)
        {
            CalendarEvent calendarEvent;
            Calendar calendar = new Calendar();

            foreach (var lesson in lessons)
            {
                calendarEvent = new CalendarEvent()
                {
                    DTStart = lesson.DateStart,
                    DTEnd = lesson.DateEnd,
                    DTStamp = DateTime.Now,
                    Summary = $"({lesson.Cabinet}) {lesson.Subject}"
                };
                calendar.Events.Add(calendarEvent);
            }

            return calendar.ToIcal();
        }
    }
}
