using System;

using Calendar.Events;
using Calendar.Events.AddPolicy;

using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests.Events.AddPolicy
{
    [TestFixture]
    class ExclusiveSchedulePolicyTests
    {
        private static readonly DateTime Tommorrow = DateTime.Today.AddDays(1);
        private static readonly DateTime DayBeforeYesterday = DateTime.Today.Subtract(TimeSpan.FromDays(2));
        private static readonly DateTime Yesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1));

        [Test]
        public void ShouldCanShareTimeSlotBeFalse()
        {
            ExclusiveSchedulePolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy();
            Assert.IsFalse(exclusiveSchedulePolicy.CanShareTimeSlot);
        }

        [Test]
        public void ShouldAddIfNoOtherMeetingIntersects()
        {
            CalendarEvent eventToAdd = Substitute.For<CalendarEvent>();
            DateSpan eventToAddSchedule = new DateSpan(DateTime.Today, Tommorrow);
            eventToAdd.Schedule.Returns(eventToAddSchedule);

            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            eventsRepository.GetEvents(eventToAdd.Schedule).Returns(new CalendarEvent[0]);

            ExclusiveSchedulePolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy();
            exclusiveSchedulePolicy.AddEventToRepository(eventToAdd, eventsRepository);

            eventsRepository.Received(1).AddEvent(eventToAdd);
        }

        [Test]
        public void ShouldNotAddWhenOtherExclusiveEventIntersects()
        {
            CalendarEvent eventToAdd = Substitute.For<CalendarEvent>();
            CalendarEvent exclusiveIntersectingEvent = Substitute.For<CalendarEvent>();
            exclusiveIntersectingEvent.AddPolicy.CanShareTimeSlot.Returns(false);

            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            eventsRepository.GetEvents(eventToAdd.Schedule).Returns(new[] { exclusiveIntersectingEvent });

            ExclusiveSchedulePolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy();
            exclusiveSchedulePolicy.AddEventToRepository(eventToAdd, eventsRepository);

            eventsRepository.Received(1).AddEvent(eventToAdd);
            Assert.Fail("unfinished");
        }
    }
}
