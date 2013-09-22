using System;

using Calendar.Events;

namespace Calendar.UI
{
    internal class AddMeetingOption : IOption
    {
        public static string AddMeetingOptionString = "M";

        private readonly Func<CalendarEventBase> meetingFactory;
        private readonly IEventsRepository eventsRepository;

        public AddMeetingOption(Func<CalendarEventBase> meetingFactory, IEventsRepository eventsRepository)
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
            CalendarEventBase calendarEvent = meetingFactory();
            eventsRepository.AddEvent(calendarEvent);
        }
    }
}