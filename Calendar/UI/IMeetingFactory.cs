using Calendar.Events;

namespace Calendar.UI
{
  internal interface IMeetingFactory
  {
    ICalendarEvent Create(DateSpan dateSpan, string title, string[] participants);
  }
}