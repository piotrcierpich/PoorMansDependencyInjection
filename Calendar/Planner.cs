using Calendar.Events;

namespace Calendar
{
    public class Planner
    {
        private readonly IEventsRepository eventsRepository;

        public Planner(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public ICalendarEvent[] GetEvents(DateSpan dateSpan)
        {
            return eventsRepository.GetEvents(dateSpan);
        }


        public void AddEvent(ICalendarEvent eventToAdd)
        {
            eventToAdd.AddPolicy.TryAddToRepository();
        }
    }
}