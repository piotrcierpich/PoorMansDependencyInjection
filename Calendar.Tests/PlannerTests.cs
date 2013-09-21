using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests
{
    [TestFixture]
    public class PlannerTests
    {
        [Test]
        public void ShouldListAllEventsWhenAskedFor()
        {
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            Planner planner = new Planner(eventsRepository);
            CalendarEvent[] events = planner.GetEvents();
            eventsRepository.Received(1).GetEvents();
        }
    }
}
