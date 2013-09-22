using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    public interface ICalendarEvent
    {
        DateSpan Schedule { get; }
        string Title { get; }
        IAddPolicy AddPolicy { get; }
    }
}