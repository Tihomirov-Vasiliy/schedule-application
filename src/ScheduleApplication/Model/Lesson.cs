using System;

namespace ScheduleApplication.Model
{
    /// <summary>
    /// Represent one lesson (lecture, laboratory or practical work)
    /// </summary>
    public class Lesson
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Cabinet { get; set; }
        public string Subject { get; set; }
        
        public Lesson(DateTime dateStart, DateTime dateEnd, string classRoom, string subject)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            Cabinet = classRoom;
            Subject = subject;
        }
    }
}
