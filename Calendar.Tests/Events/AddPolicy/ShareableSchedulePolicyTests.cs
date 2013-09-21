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
            ShareableSchedulePolicy shareableSchedulePolicy = new ShareableSchedulePolicy();
            Assert.IsTrue(shareableSchedulePolicy.CanShareTimeSlot);
        }

        [Test]
        public void ShouldAddToEventsRepositoryWhenAskedFor()
        {
            CalendarEvent calendarEvent = Substitute.For<CalendarEvent>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            ShareableSchedulePolicy shareableSchedulePolicy = new ShareableSchedulePolicy();
            shareableSchedulePolicy.AddEventToRepository(calendarEvent, eventsRepository);
        }
    }
}
