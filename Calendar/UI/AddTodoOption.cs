using System;

using Calendar.Events;
using Calendar.Logging;

namespace Calendar.UI
{
  class AddTodoOption : IOption
  {
    internal const string AddToDoOptionString = "a";

    private readonly ITodoFactory todoEventFactory;
    private readonly IPlanner planner;
    private readonly ILogger _logger;

    public AddTodoOption(ITodoFactory todoEventFactory, IPlanner planner, ILogger logger)
    {
      this.todoEventFactory = todoEventFactory;
      this.planner = planner;
      _logger = logger;
    }

    public virtual bool MatchesString(string chosenOptionAsString)
    {
      _logger.Log("Matches string");
      bool result = StringComparer.InvariantCultureIgnoreCase.Equals(chosenOptionAsString, AddToDoOptionString);
      _logger.Log("Matches string completed");
      return result;
    }

    public sealed override string ToString()
    {
      return AddToDoOptionString + " - todo";
    }

    public virtual bool Run()
    {
      _logger.Log("Run");
      DateSpan schedule = DateSpanReader.PromptForDateSpan();
      Console.Write("Title: ");
      string title = Console.ReadLine();
      ICalendarEvent todoEvent = todoEventFactory.Create(schedule, title);
      planner.AddEvent(todoEvent);
      _logger.Log("Run completed");
      return true;
    }
  }
}