using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    public abstract class CalendarEvent
    {
        public DateSpan Schedule { get; set; }
        public string Title { get; set; }

        public IAddPolicy AddPolicy { get; set; }
    }
}