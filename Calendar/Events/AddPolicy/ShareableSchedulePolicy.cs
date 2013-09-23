namespace Calendar.Events.AddPolicy
{
    class ShareableSchedulePolicy : IAddPolicy
    {
        private readonly IEventsRepository eventsRepository;

        public ShareableSchedulePolicy(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public void TryAddToRepository(ICalendarEvent calendarEvent)
        {
            eventsRepository.AddEvent(calendarEvent);
        }
    }
}
