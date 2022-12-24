using ScheduleApplication.Intefraces;
using System;
using System.IO;

namespace ScheduleApplication.Services
{
    /// <summary>
    /// Default implementation of <see cref="IFileService"/>
    /// </summary>
    public class DefaultCreateService : IFileService
    {
        public void Create(string groupName, string path, string stringContent)
        {
            string resultPath = $"{path}\\{Constants.NAME_OF_FILE_BASIC} {groupName} от {DateTime.Now.ToShortDateString()}.ical" ;
            File.WriteAllText(resultPath, stringContent);
        }
    }
}
