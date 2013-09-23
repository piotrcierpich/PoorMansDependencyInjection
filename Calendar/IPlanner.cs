using Calendar.Events;

namespace Calendar
{
    public interface IPlanner
    {
        ICalendarEvent[] GetEvents(DateSpan dateSpan);
        void AddEvent(ICalendarEvent eventToAdd);
    }
}