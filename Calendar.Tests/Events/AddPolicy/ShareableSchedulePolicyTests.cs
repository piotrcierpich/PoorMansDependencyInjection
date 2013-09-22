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
            ICalendarEvent calendarEvent = Substitute.For<ICalendarEvent>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            ShareableSchedulePolicy shareableSchedulePolicy = new ShareableSchedulePolicy(eventsRepository) { CalendarEvent = calendarEvent };
            Assert.IsTrue(shareableSchedulePolicy.CanShareTimeSlot);
        }

        [Test]
        public void ShouldAddToEventsRepositoryWhenAskedFor()
        {
            ICalendarEvent calendarEvent = Substitute.For<ICalendarEvent>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            ShareableSchedulePolicy shareableSchedulePolicy = new ShareableSchedulePolicy(eventsRepository) { CalendarEvent = calendarEvent };
            shareableSchedulePolicy.TryAddToRepository();
            eventsRepository.Received(1).AddEvent(calendarEvent);
        }
    }
}
