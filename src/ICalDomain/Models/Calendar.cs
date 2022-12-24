using ICalDomain.Interfaces;
using System.Text;

namespace ICalDomain.Models
{
    /// <summary>
    /// Represents simple Calendar object
    /// </summary>
    public class Calendar : IFormatConvetor
    {
        /// <summary>
        /// Current calendar event list
        /// </summary>
        public IList<CalendarEvent> Events { get; private set; }

        public Calendar()
        {
            Events = new List<CalendarEvent>();
        }

        /// <summary>
        /// Implemented interface method <see cref="IFormatConvetor.ToIcal"/>
        /// </summary>
        /// <returns>String value that represent calendar object</returns>
        public string ToIcal()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("BEGIN:VCALENDAR");
            stringBuilder.AppendLine($"PRODID:-//SibadiScheduleCreator");
            stringBuilder.AppendLine($"VERSION:2.0");

            if (Events.Count != 0 && Events != null)
                foreach (var calendarEvent in Events)
                {
                    stringBuilder.Append(calendarEvent.ToIcal());
                }

            stringBuilder.AppendLine("END:VCALENDAR");
            return stringBuilder.ToString();
        }
    }
}
