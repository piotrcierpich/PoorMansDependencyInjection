namespace Calendar.Events.AddPolicy
{
    public interface IAddPolicy
    {
        void TryAddToRepository();
        bool CanShareTimeSlot { get; }
    }
}