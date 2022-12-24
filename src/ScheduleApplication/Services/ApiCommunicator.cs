using Newtonsoft.Json.Linq;
using ScheduleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleApplication.Services
{
    /// <summary>
    /// Represents communicator with university API
    /// </summary>
    public static class ApiCommunicator
    {
        public static List<Lesson> GetLessonList(int groupId, LessonDateRules dateRules, DateTime currentDate, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            List<Lesson> events = new List<Lesson>();
            Lesson newEvent;

            DateTime startLessonTime;
            DateTime endLessonTime;
            string subject;
            string classRoom;

            JObject jsonResponse = JObject.Parse(Request.Get(EventDateRulesHandler.GetRequestUri(groupId, dateRules, currentDate)));

            var data = jsonResponse["data"];
            var rasp = data["rasp"];

            foreach (var lesson in rasp)
            {
                startLessonTime = (DateTime)lesson["датаНачала"];
                endLessonTime = (DateTime)lesson["датаОкончания"];
                classRoom = lesson["аудитория"].ToString();
                subject = lesson["дисциплина"].ToString();

                newEvent = new Lesson(startLessonTime, endLessonTime, classRoom, subject);

                if (newEvent != null)
                    events.Add(newEvent);
            }

            if (dateRules == LessonDateRules.DateRange)
                return events
                    .Where(e => e.DateStart >= dateStart.GetValueOrDefault() &&
                                e.DateStart <= dateEnd.GetValueOrDefault())
                    .ToList();

            return events;
        }
        public static Group GetGroupIfExist(string groupName)
        {
            JObject jsonResponse = JObject.Parse(Request.Get(Constants.GROUPS_API_URL));
            string currentGroupName;
            groupName = groupName.Trim().ToLower();

            var groups = jsonResponse["data"];
            foreach (var group in groups)
            {
                currentGroupName = group["name"].ToString().ToLower();
                if (currentGroupName == groupName)
                    return new Group(int.Parse(group["id"].ToString()), currentGroupName);
            }
            return null;
        }
        public static List<Group> GetGroupListForCurrentYear()
        {
            JObject jsonResponse = JObject.Parse(Request.Get(Constants.GROUPS_API_URL));

            var groups = jsonResponse["data"];
            List<Group> groupList = new List<Group>();

            foreach (var group in groups)
                groupList.Add(new Group((int)group["id"], group["name"].ToString()));

            return groupList;
        }
    }
}
