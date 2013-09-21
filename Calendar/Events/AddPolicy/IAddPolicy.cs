namespace Calendar.Events.AddPolicy
{
    public interface IAddPolicy
    {
        void AddEventToRepository(CalendarEvent calendarEvent,  IEventsRepository eventsRepository);
        bool CanShareTimeSlot { get; }
    }
}