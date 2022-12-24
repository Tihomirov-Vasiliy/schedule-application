namespace ICalDomain.Interfaces
{
    /// <summary>
    /// Provides rule for creating string in Ical Format from current entity <see cref="ToIcal"/>
    /// </summary>
    public interface IFormatConvetor 
    {
        string ToIcal();   
    }
}
