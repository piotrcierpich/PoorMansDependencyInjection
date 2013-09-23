using Calendar.Events;

namespace Calendar
{
    public class Planner : IPlanner
    {
        private readonly IEventsRepository eventsRepository;

        public Planner(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public virtual ICalendarEvent[] GetEvents(DateSpan dateSpan)
        {
            return eventsRepository.GetEvents(dateSpan);
        }


        public virtual void AddEvent(ICalendarEvent eventToAdd)
        {
            eventToAdd.AddPolicy.TryAddToRepository();
        }
    }
}