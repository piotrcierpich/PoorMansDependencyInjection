using System;

using Calendar.Events;

namespace Calendar.UI
{
    class AddTodoOption : IOption
    {
        internal const string AddToDoOptionString = "a";

        private readonly Func<DateSpan, string, Todo> todoEventFactory;
        private readonly IEventsRepository eventsRepository;

        public AddTodoOption(Func<DateSpan, string, Todo> todoEventFactory, IEventsRepository eventsRepository)
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
            return AddToDoOptionString + " - todo";
        }

        public void Run()
        {
            DateSpan schedule = DateSpanReader.PromptForDateSpan();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            ICalendarEvent calendarEvent = todoEventFactory(schedule, title);
            eventsRepository.AddEvent(calendarEvent);
        }
    }
}