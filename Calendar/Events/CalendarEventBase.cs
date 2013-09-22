using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    public abstract class CalendarEventBase : ICalendarEvent
    {
        private readonly DateSpan schedule;
        private readonly string title;
        private readonly IAddPolicy addPolicy;

        protected CalendarEventBase(DateSpan schedule, string title, IAddPolicy addPolicy)
        {
            this.schedule = schedule;
            this.title = title;
            this.addPolicy = addPolicy;
        }

        public DateSpan Schedule { get { return schedule; } }
        public string Title { get { return title; } }
        public IAddPolicy AddPolicy { get { return addPolicy; } }
    }
}