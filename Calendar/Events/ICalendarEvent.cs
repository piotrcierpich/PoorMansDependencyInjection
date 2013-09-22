using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    public interface ICalendarEvent
    {
        DateSpan Schedule { get; set; }
        string Title { get; set; }
        IAddPolicy AddPolicy { get; }
    }
}