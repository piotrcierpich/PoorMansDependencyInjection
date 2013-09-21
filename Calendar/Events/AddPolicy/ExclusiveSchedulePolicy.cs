namespace Calendar.Events.AddPolicy
{
    internal class ExclusiveSchedulePolicy : IAddPolicy
    {
        public void AddEventToRepository(CalendarEvent calendarEvent, IEventsRepository eventsRepository)
        {
            throw new System.NotImplementedException();
        }

        public bool CanShareTimeSlot
        {
            get { return false; }
        }
    }
}