namespace Calendar.Events
{
    public interface IEventsRepository
    {
        CalendarEvent[] GetEvents(DateSpan schedule);
        void AddEvent(CalendarEvent eventToAdd);
    }
}