using Calendar.Events;

namespace Calendar.UI
{
  internal interface ITodoFactory
  {
    ICalendarEvent Create(DateSpan schedule, string title);
  }
}