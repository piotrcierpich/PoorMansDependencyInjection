using System;

using Calendar.Events;

namespace Calendar.UI
{
    internal class AddMeetingOption : IOption
    {
        public static string AddMeetingOptionString = "m";

        private readonly Func<ICalendarEvent> meetingFactory;
        private readonly IEventsRepository eventsRepository;

        public AddMeetingOption(Func<ICalendarEvent> meetingFactory, IEventsRepository eventsRepository)
        {
            this.meetingFactory = meetingFactory;
            this.eventsRepository = eventsRepository;
        }

        public bool MatchesString(string chosenOptionAsString)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(AddMeetingOptionString, chosenOptionAsString);
        }

        public void Run()
        {
            ICalendarEvent calendarEvent = meetingFactory();
            eventsRepository.AddEvent(calendarEvent);
        }

        public override string ToString()
        {
            return AddMeetingOptionString + " - meeting";
        }
    }
}