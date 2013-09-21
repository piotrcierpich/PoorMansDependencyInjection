using Calendar.Events;
using Calendar.Events.AddPolicy;

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
            DateSpan dateSpan = Arg.Any<DateSpan>();
            planner.GetEvents(dateSpan);
            eventsRepository.Received(1).GetEvents(dateSpan);
        }

        [Test]
        public void ShouldAddToRepositoryWhenAskedFor()
        {
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            Planner planner = new Planner(eventsRepository);
            CalendarEvent eventToAdd = Substitute.For<CalendarEvent>();
            planner.AddEvent(eventToAdd);
            //eventToAdd.Received(1).AddToEventsRepository(eventsRepository);
            Assert.Fail("not implemented");
        }
    }
}
