using System;

using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    [Serializable]
    class Todo : CalendarEventBase
    {
        public Todo(DateSpan schedule, string title, IAddPolicy addPolicy) : base(schedule, title, addPolicy) { }

        public override string ToString()
        {
            return "TODO " + Title + Environment.NewLine
                   + "start date: " + Schedule.StartTime + Environment.NewLine
                   + "end date: " + Schedule.EndTime + Environment.NewLine;
        }
    }
}