namespace ScheduleApplication.Model
{
    /// <summary>
    /// Represents group in the university
    /// </summary>
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }

        public Group(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Group(int id, string name, string faculty, int course) : this(id, name)
        {
            Faculty = faculty;
            Course = course;
        }
    }
}
