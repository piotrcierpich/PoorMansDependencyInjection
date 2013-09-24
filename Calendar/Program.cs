using System;
using Calendar.DataAccess;
using Calendar.Events;
using Calendar.Events.AddPolicy;
using Calendar.Logging;
using Calendar.UI;

namespace Calendar
{
  class Program
  {
    static void Main()
    {
      using (Logger logger = new Logger())
      {
        IEventsRepository eventsRepository = new EventsRepository("calendarData.dat");
        IAddPolicy shareableSchedulePolicy = new ShareableSchedulePolicy(eventsRepository);
        IAddPolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy(eventsRepository);

        Planner planner = new Planner(eventsRepository, shareableSchedulePolicy, exclusiveSchedulePolicy);

        IMeetingFactory meetingFactory = new MeetingFactory();
        IOption addMeetingOption = new AddMeetingOption(meetingFactory, planner, logger);

        ITodoFactory todoFactory = new TodoFactory();
        IOption addTodoOption = new AddTodoOption(todoFactory, planner, logger);

        IOption listEventsOption = new ListEventsOption(planner);

        IOption endApplicationOption = new EndApplicationOption();

        OptionsDispatcher optionsDispatcher = new OptionsDispatcher(new[]
          {
            addTodoOption,
            addMeetingOption,
            listEventsOption,
            endApplicationOption,
          }, 
          Console.In, 
          logger);

        bool result = true;
        while (result)
        {
          result = optionsDispatcher.ChooseOptionAndRun();
        }
      }
    }
  }
}
