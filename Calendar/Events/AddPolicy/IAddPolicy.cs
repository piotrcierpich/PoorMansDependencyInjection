namespace Calendar.Events.AddPolicy
{
    public interface IAddPolicy
    {
        void TryAddToRepository(ICalendarEvent eventToAdd);
    }
}