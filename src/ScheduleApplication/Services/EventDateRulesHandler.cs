using ScheduleApplication.Model;
using System;

namespace ScheduleApplication.Services
{
    /// <summary>
    /// Handler for <see cref="LessonDateRules"/>. 
    /// </summary>
    public static class EventDateRulesHandler
    {
        /// <summary>
        /// Getting correct request Uri
        /// </summary>
        /// <returns>Correct request Uri depending on <see cref="LessonDateRules"/></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string GetRequestUri(int groupId, LessonDateRules dateOfRules, DateTime currentDate)
        {
            if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                currentDate = currentDate.AddDays(-2);

            switch (dateOfRules)
            {
                case LessonDateRules.NextWeek:
                    currentDate = currentDate.AddDays(7);
                    break;
                case LessonDateRules.ThisWeek:
                    break;
                case LessonDateRules.DateRange:
                    return Constants.RASP_API_WITH_GROUP_ID_URL + groupId;
                default:
                    throw new ArgumentException(Constants.ERROR_THERE_IS_NO_THAT_EVENTDATERULES);
            }

            return Constants.RASP_API_WITH_GROUP_ID_URL + groupId +
                   Constants.RASP_API_DATE_PARAMETER + currentDate.ToString("yyyy-MM-dd"); ;
        }
    }
}
