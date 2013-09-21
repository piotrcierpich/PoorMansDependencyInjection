namespace Calendar.Events.AddPolicy
{
    class ShareableSchedulePolicy : IAddPolicy
    {
        public void AddEventToRepository(CalendarEvent calendarEvent, IEventsRepository eventsRepository)
        {
            eventsRepository.AddEvent(calendarEvent);
        }

        public bool CanShareTimeSlot { get { return true; } }
    }
}
