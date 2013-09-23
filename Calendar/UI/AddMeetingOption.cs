using System;

using Calendar.Events;

namespace Calendar.UI
{
  internal class AddMeetingOption : IOption
  {
    public static string AddMeetingOptionString = "m";

    private readonly Func<DateSpan, string, string[], Meeting> meetingFactory;
    private readonly IEventsRepository eventsRepository;

    public AddMeetingOption(Func<DateSpan, string, string[], Meeting> meetingFactory, IEventsRepository eventsRepository)
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
      DateSpan dateSpan = DateSpanReader.PromptForDateSpan();
      string title = PromptForTitle();
      string[] participants = PromptForParticipants();

      ICalendarEvent calendarEvent = meetingFactory(dateSpan, title, participants);
      eventsRepository.AddEvent(calendarEvent);
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

    public override string ToString()
    {
      return AddMeetingOptionString + " - meeting";
    }
  }
}