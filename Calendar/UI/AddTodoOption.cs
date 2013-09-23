using System;

using Calendar.Events;

namespace Calendar.UI
{
    class AddTodoOption : IOption
    {
        internal const string AddToDoOptionString = "a";

        private readonly Func<DateSpan, string, Todo> todoEventFactory;
        private readonly IPlanner planner;

        public AddTodoOption(Func<DateSpan, string, Todo> todoEventFactory, IPlanner planner)
        {
            this.todoEventFactory = todoEventFactory;
            this.planner = planner;
        }

        public bool MatchesString(string chosenOptionAsString)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(chosenOptionAsString, AddToDoOptionString);
        }

        public override string ToString()
        {
            return AddToDoOptionString + " - todo";
        }

        public bool Run()
        {
            DateSpan schedule = DateSpanReader.PromptForDateSpan();
            Console.Write("Title: ");
            string title = Console.ReadLine();
            ICalendarEvent todoEvent = todoEventFactory(schedule, title);
            planner.AddEvent(todoEvent);
            return true;
        }
    }
}