using System;

using Calendar.Events;

namespace Calendar.UI
{
    class ListEventsOption : IOption
    {
        internal const string ListEventsOptionString = "l";

        private readonly IEventsRepository eventsRepository;

        public ListEventsOption(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        public bool MatchesString(string chosenOptionAsString)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(ListEventsOptionString, chosenOptionAsString);
        }

        public void Run()
        {
            ICalendarEvent[] calendarEvents = eventsRepository.GetEvents(DateSpan.Max);
            foreach (var calendarEvent in calendarEvents)
            {
                Console.WriteLine(calendarEvent);
            }
        }

        public override string ToString()
        {
            return ListEventsOptionString + " - list events";
        }
    }
}
