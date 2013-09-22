using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    class Todo : CalendarEventBase
    {
        public Todo(DateSpan schedule, string title, IAddPolicy addPolicy) : base(schedule, title, addPolicy) {}
    }
}