using System;

using Calendar.Events;

namespace Calendar.UI
{
    internal class AddMeetingOption : IOption
    {
        public static string AddMeetingOptionString = "m";

        private readonly Func<DateSpan, string, string[], Meeting> meetingFactory;
        private readonly IPlanner planner;

        public AddMeetingOption(Func<DateSpan, string, string[], Meeting> meetingFactory, IPlanner planner)
        {
            this.meetingFactory = meetingFactory;
            this.planner = planner;
        }

        public virtual bool MatchesString(string chosenOptionAsString)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(AddMeetingOptionString, chosenOptionAsString);
        }

        public virtual bool Run()
        {
            DateSpan dateSpan = DateSpanReader.PromptForDateSpan();
            string title = PromptForTitle();
            string[] participants = PromptForParticipants();

            ICalendarEvent meetingEvent = meetingFactory(dateSpan, title, participants);
            planner.AddEvent(meetingEvent);
            return true;
        }

        private string[] PromptForParticipants()
        {
            Console.Write("Participants' names separated with comas: ");
            string participantsAsString = Console.ReadLine();
            return participantsAsString != null
                     ? participantsAsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                     : new string[0];
        }

        private static string PromptForTitle()
        {
            Console.Write("Title: ");
            return Console.ReadLine();
        }

        public sealed override string ToString()
        {
            return AddMeetingOptionString + " - meeting";
        }
    }
}