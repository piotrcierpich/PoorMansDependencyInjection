using System;

namespace Calendar.Events
{
    [Serializable]
    public abstract class CalendarEventBase : ICalendarEvent
    {
        private readonly DateSpan schedule;
        private readonly string title;

        protected CalendarEventBase(DateSpan schedule, string title)
        {
            this.schedule = schedule;
            this.title = title;
        }

        public DateSpan Schedule { get { return schedule; } }
        public string Title { get { return title; } }
        public bool CanShareTime { get; set; }
    }
}