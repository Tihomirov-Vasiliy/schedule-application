using System;

namespace ScheduleApplication.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string message) : base(message)
        {

        }
    }
}
