using System;

using Calendar.Events;
using Calendar.Logging;

namespace Calendar.UI
{
  internal class AddMeetingOption : IOption
  {
    public static string AddMeetingOptionString = "m";

    private readonly IMeetingFactory meetingFactory;
    private readonly IPlanner planner;
    private readonly ILogger _logger;

    public AddMeetingOption(IMeetingFactory meetingFactory, IPlanner planner, ILogger logger)
    {
      this.meetingFactory = meetingFactory;
      this.planner = planner;
      _logger = logger;
    }

    public virtual bool MatchesString(string chosenOptionAsString)
    {
      _logger.Log("Matching string");
      bool result = StringComparer.InvariantCultureIgnoreCase.Equals(AddMeetingOptionString, chosenOptionAsString);
      _logger.Log("Matches string completed");
      return result;
    }

    public virtual bool Run()
    {
      _logger.Log("Run");
      DateSpan dateSpan = DateSpanReader.PromptForDateSpan();
      string title = PromptForTitle();
      string[] participants = PromptForParticipants();

      ICalendarEvent meetingEvent = meetingFactory.Create(dateSpan, title, participants);
      planner.AddEvent(meetingEvent);
      _logger.Log("Run completed");

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