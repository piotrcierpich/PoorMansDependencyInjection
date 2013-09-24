using Calendar.Events;

namespace Calendar.UI
{
  class TodoFactory : ITodoFactory
  {
    public ICalendarEvent Create(DateSpan schedule, string title)
    {
      return new Todo(schedule, title);
    }
  }
}