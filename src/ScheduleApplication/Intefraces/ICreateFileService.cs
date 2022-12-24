namespace ScheduleApplication.Intefraces
{
    /// <summary>
    /// Interface for creating file depending on group name, path and string content
    /// </summary>
    public interface IFileService
    {
        void Create(string groupName, string path, string stringContent);
    }
}
