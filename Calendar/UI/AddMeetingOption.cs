using System;

using Calendar.Events;

namespace Calendar.UI
{
    internal class AddMeetingOption : IOption
    {
        public static string AddMeetingOptionString = "M";

        private readonly Func<CalendarEvent> meetingFactory;
        private readonly IEventsRepository eventsRepository;

        public AddMeetingOption(Func<CalendarEvent> meetingFactory, IEventsRepository eventsRepository)
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
            CalendarEvent calendarEvent = meetingFactory();
            eventsRepository.AddEvent(calendarEvent);
        }
    }
}