using System.Linq;

using Calendar.Events.AddPolicy;

namespace Calendar.Events
{
    class Meeting : CalendarEventBase
    {
        private readonly string[] participants;

        public Meeting(DateSpan schedule, string title, IAddPolicy addPolicy, string[] participants)
            : base(schedule, title, addPolicy)
        {
            this.participants = participants;
        }

        public string[] Participants { get { return participants; } }

        public override string ToString()
        {
            return "Meeting '" + Title + "' with " + Participants.Aggregate((p1, p2) => p1 + p2)
                    + " scheduled at " + Schedule.StartTime + ", until " + Schedule.EndTime;
        }
    }
}