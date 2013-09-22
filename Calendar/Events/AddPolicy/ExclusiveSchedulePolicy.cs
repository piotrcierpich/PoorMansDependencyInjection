using System.Linq;

namespace Calendar.Events.AddPolicy
{
    internal class ExclusiveSchedulePolicy : IAddPolicy
    {
        private readonly IEventsRepository eventsRepository;
        private readonly ICalendarEvent eventToAdd;

        public ExclusiveSchedulePolicy(IEventsRepository eventsRepository, ICalendarEvent eventToAdd)
        {
            this.eventsRepository = eventsRepository;
            this.eventToAdd = eventToAdd;
        }

        public void TryAddToRepository()
        {
            ICalendarEvent[] intersectingEvents = eventsRepository.GetEvents(eventToAdd.Schedule);
            if (intersectingEvents.All(ie => ie.AddPolicy.CanShareTimeSlot))
            {
                eventsRepository.AddEvent(eventToAdd);
            }
        }

        public bool CanShareTimeSlot
        {
            get { return false; }
        }
    }
}