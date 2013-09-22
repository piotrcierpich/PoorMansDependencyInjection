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
            DateSpan dateSpan = DateSpan.Max;
            planner.GetEvents(dateSpan);
            eventsRepository.Received(1).GetEvents(dateSpan);
        }

        [Test]
        public void ShouldAddToRepositoryWhenAskedFor()
        {
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            Planner planner = new Planner(eventsRepository);
            ICalendarEvent eventToAdd = Substitute.For<ICalendarEvent>();
            IAddPolicy addPolicy = Substitute.For<IAddPolicy>();
            eventToAdd.AddPolicy.Returns(addPolicy);

            planner.AddEvent(eventToAdd);
            addPolicy.Received(1).TryAddToRepository();
        }
    }
}
