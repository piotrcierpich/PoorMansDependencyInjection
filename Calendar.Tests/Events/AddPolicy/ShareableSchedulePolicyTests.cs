using Calendar.Events;
using Calendar.Events.AddPolicy;

using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests.Events.AddPolicy
{
    [TestFixture]
    class ShareableSchedulePolicyTests
    {
        [Test]
        public void ShouldCanShareTimeSlotBeTrue()
        {
            CalendarEventBase calendarEvent = Substitute.For<CalendarEventBase>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            ShareableSchedulePolicy shareableSchedulePolicy = new ShareableSchedulePolicy(eventsRepository, calendarEvent);
            Assert.IsTrue(shareableSchedulePolicy.CanShareTimeSlot);
        }

        [Test]
        public void ShouldAddToEventsRepositoryWhenAskedFor()
        {
            CalendarEventBase calendarEvent = Substitute.For<CalendarEventBase>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            ShareableSchedulePolicy shareableSchedulePolicy = new ShareableSchedulePolicy(eventsRepository, calendarEvent);
            shareableSchedulePolicy.TryAddToRepository();
            eventsRepository.Received(1).AddEvent(calendarEvent);
        }
    }
}
