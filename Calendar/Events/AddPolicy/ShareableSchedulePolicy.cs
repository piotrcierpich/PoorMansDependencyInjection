namespace Calendar.Events.AddPolicy
{
    class ShareableSchedulePolicy : IAddPolicy
    {
        private readonly IEventsRepository eventsRepository;
        private readonly CalendarEventBase calendarEvent;

        public ShareableSchedulePolicy(IEventsRepository eventsRepository, CalendarEventBase calendarEvent)
        {
            this.eventsRepository = eventsRepository;
            this.calendarEvent = calendarEvent;
        }

        public void TryAddToRepository()
        {
            eventsRepository.AddEvent(calendarEvent);
        }

        public bool CanShareTimeSlot { get { return true; } }
    }
}
