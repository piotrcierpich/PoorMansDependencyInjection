using System;

using Calendar.Events;

namespace Calendar.UI
{
    class AddTodoOption : IOption
    {
        internal const string AddToDoOptionString = "a";

        private readonly Func<ICalendarEvent> todoEventFactory;
        private readonly IEventsRepository eventsRepository;

        public AddTodoOption(Func<ICalendarEvent> todoEventFactory, IEventsRepository eventsRepository)
        {
            this.todoEventFactory = todoEventFactory;
            this.eventsRepository = eventsRepository;
        }

        public bool MatchesString(string chosenOptionAsString)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(chosenOptionAsString, AddToDoOptionString);
        }

        public override string ToString()
        {
            return AddToDoOptionString;
        }

        public void Run()
        {
            ICalendarEvent calendarEvent = todoEventFactory();
            eventsRepository.AddEvent(calendarEvent);
        }
    }
}