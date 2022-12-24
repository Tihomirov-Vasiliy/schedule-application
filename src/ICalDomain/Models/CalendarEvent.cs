using ICalDomain.Interfaces;
using System.Text;

namespace ICalDomain.Models
{
    /// <summary>
    /// Represents event in any calendar with properties <see cref="DTEnd"/>
    /// </summary>
    public class CalendarEvent : IFormatConvetor
    {
        /// <summary>
        /// Event end time
        /// </summary>
        public DateTime DTEnd { private get; set; }

        /// <summary>
        /// Event start time
        /// </summary>
        public DateTime DTStart { private get; set; }

        /// <summary>
        /// Time when instance current event was created
        /// </summary>
        public DateTime DTStamp { private get; set; }

        /// <summary>
        /// Summary text of event. Usually represent main text of event 
        /// </summary>
        public string Summary { private get; set; }

        /// <summary>
        /// Implemented interface method <see cref="IFormatConvetor.ToIcal"/>
        /// </summary>
        /// <returns>String value that represent calendar event object</returns>
        public string ToIcal()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("BEGIN:VEVENT");
            stringBuilder.AppendLine($"DTSTAMP:{DTStamp.ToString("yyyyMMdd'T'HHmmss'Z'")}");
            stringBuilder.AppendLine($"DTSTART:{DTStart.ToString("yyyyMMdd'T'HHmmss")}");
            stringBuilder.AppendLine($"DTEND:{DTEnd.ToString("yyyyMMdd'T'HHmmss")}");
            stringBuilder.AppendLine($"SUMMARY:{Summary}");
            stringBuilder.AppendLine("END:VEVENT");

            return stringBuilder.ToString();
        }
    }
}
