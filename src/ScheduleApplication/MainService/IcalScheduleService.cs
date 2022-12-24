using ScheduleApplication.Intefraces;
using ScheduleApplication.Model;
using ScheduleApplication.Services;
using System;

namespace ScheduleApplication.MainService
{
    /// <summary>
    /// Represents service for getting Ical content or files depends on group name, current date and lessonDateRules
    /// </summary>
    public class IcalScheduleService
    {
        private IFileService _fileService;

        public IcalScheduleService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public string GetIcalString(string groupName, LessonDateRules dateRules, DateTime currentDate, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            var group = ApiCommunicator.GetGroupIfExist(groupName);
            var eventList = ApiCommunicator.GetLessonList(group.Id, dateRules, currentDate, dateStart, dateEnd);

            return IcalService.GetStringOfIcalFile(eventList);
        }
        public void CreateIcalFile(string path, string groupName, LessonDateRules dateRules, DateTime currentDate, DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            _fileService.Create(groupName, path, GetIcalString(groupName, dateRules, currentDate, dateStart, dateEnd));
        }
    }
}
