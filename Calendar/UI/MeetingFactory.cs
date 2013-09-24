using Calendar.Events;

namespace Calendar.UI
{
  class MeetingFactory : IMeetingFactory
  {
    public ICalendarEvent Create(DateSpan dateSpan, string title, string[] participants)
    {
      return new Meeting(dateSpan, title, participants);
    }
  }
}