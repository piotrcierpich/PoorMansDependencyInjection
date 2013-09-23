using Calendar.Events;
using Calendar.Events.AddPolicy;

namespace Calendar
{
    public class Planner : IPlanner
    {
        private readonly IEventsRepository eventsRepository;
        private readonly IAddPolicy shareableSchedulePolicy;
        private readonly IAddPolicy exclusiveSchedulePolicy;

        public Planner(IEventsRepository eventsRepository,
                       IAddPolicy shareableSchedulePolicy,
                       IAddPolicy exclusiveSchedulePolicy)
        {
            this.eventsRepository = eventsRepository;
            this.shareableSchedulePolicy = shareableSchedulePolicy;
            this.exclusiveSchedulePolicy = exclusiveSchedulePolicy;
        }

        public ICalendarEvent[] GetEvents(DateSpan dateSpan)
        {
            return eventsRepository.GetEvents(dateSpan);
        }

        public void AddEvent(ICalendarEvent eventToAdd)
        {
            if (eventToAdd.CanShareTime)
                shareableSchedulePolicy.TryAddToRepository(eventToAdd);
            else
                exclusiveSchedulePolicy.TryAddToRepository(eventToAdd);
        }
    }
}