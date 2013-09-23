using System;
using System.Linq;

namespace Calendar.Events.AddPolicy
{
    [Serializable]
    internal class ExclusiveSchedulePolicy : IAddPolicy
    {
        [NonSerialized]
        private readonly IEventsRepository eventsRepository;

        public ExclusiveSchedulePolicy(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public void TryAddToRepository()
        {
            if (EventToAdd == null)
                return;

            ICalendarEvent[] intersectingEvents = eventsRepository.GetEvents(EventToAdd.Schedule);
            if (intersectingEvents.All(ie => ie.AddPolicy.CanShareTimeSlot))
            {
                eventsRepository.AddEvent(EventToAdd);
            }
        }

        public bool CanShareTimeSlot
        {
            get { return false; }
        }

        
        public ICalendarEvent EventToAdd { get; set; }
    }
}