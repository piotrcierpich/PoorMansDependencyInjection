using System;

namespace Calendar.Events.AddPolicy
{
    [Serializable]
    class ShareableSchedulePolicy : IAddPolicy
    {
        [NonSerialized]
        private readonly IEventsRepository eventsRepository;

        public ShareableSchedulePolicy(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public void TryAddToRepository()
        {
            if (CalendarEvent == null)
                return;

            eventsRepository.AddEvent(CalendarEvent);
        }

        public bool CanShareTimeSlot { get { return true; } }

        public ICalendarEvent CalendarEvent { get; set; }
    }
}
