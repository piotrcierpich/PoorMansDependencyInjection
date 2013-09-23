using System;

using Calendar.Events;

namespace Calendar.UI
{
    class ListEventsOption : IOption
    {
        internal const string ListEventsOptionString = "l";

        private readonly IPlanner planner;

        public ListEventsOption(IPlanner planner)
        {
            this.planner = planner;
        }

        public virtual bool MatchesString(string chosenOptionAsString)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(ListEventsOptionString, chosenOptionAsString);
        }

        public virtual bool Run()
        {
            ICalendarEvent[] calendarEvents = planner.GetEvents(DateSpan.Max);
            foreach (var calendarEvent in calendarEvents)
            {
                Console.WriteLine(calendarEvent);
            }
            return true;
        }

        public sealed override string ToString()
        {
            return ListEventsOptionString + " - list events";
        }
    }
}
