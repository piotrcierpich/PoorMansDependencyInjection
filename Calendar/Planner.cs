using System;

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

        public CalendarEvent[] GetEvents(DateSpan dateSpan)
        {
            return eventsRepository.GetEvents(dateSpan);
        }

        public void AddEvent(CalendarEvent eventToAdd)
        {
            throw new NotImplementedException();
            //eventToAdd.AddToEventsRepository(eventsRepository);
        }
    }
}