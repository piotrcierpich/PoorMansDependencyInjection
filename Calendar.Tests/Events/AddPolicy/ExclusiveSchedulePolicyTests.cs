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

        [Test]
        public void ShouldAddIfNoOtherMeetingIntersects()
        {
            //ICalendarEvent eventToAdd = Substitute.For<ICalendarEvent>();
            //DateSpan eventToAddSchedule = new DateSpan(DateTime.Today, Tommorrow);
            //eventToAdd.Schedule.Returns(eventToAddSchedule);

            //IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            //eventsRepository.GetEvents(eventToAdd.Schedule).Returns(new ICalendarEvent[0]);

            //ExclusiveSchedulePolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy(eventsRepository) { EventToAdd = eventToAdd };
            //exclusiveSchedulePolicy.TryAddToRepository();

            //eventsRepository.Received(1).AddEvent(eventToAdd);
        }

        [Test]
        public void ShouldNotAddWhenOtherExclusiveEventIntersects()
        {
            //ICalendarEvent eventToAdd = Substitute.For<ICalendarEvent>();
            //ICalendarEvent exclusiveIntersectingEvent = Substitute.For<ICalendarEvent>();
            //IAddPolicy nonShareablePolicy = Substitute.For<IAddPolicy>();
            //nonShareablePolicy.CanShareTimeSlot.Returns(false);
            //exclusiveIntersectingEvent.AddPolicy.Returns(nonShareablePolicy);

            //IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            //eventsRepository.GetEvents(eventToAdd.Schedule).Returns(new[] { exclusiveIntersectingEvent });

            //ExclusiveSchedulePolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy(eventsRepository);
            //exclusiveSchedulePolicy.TryAddToRepository();

            //eventsRepository.DidNotReceive().AddEvent(eventToAdd);
        }

        [Test]
        public void ShouldAddWhenOtherEventsCanShareTimeSlot()
        {
            //ICalendarEvent eventToAdd = Substitute.For<ICalendarEvent>();
            //ICalendarEvent nonExclusiveIntersectingEvent = Substitute.For<ICalendarEvent>();
            //IAddPolicy shareablePolicy = Substitute.For<IAddPolicy>();
            //shareablePolicy.CanShareTimeSlot.Returns(true);
            //nonExclusiveIntersectingEvent.AddPolicy.Returns(shareablePolicy);

            //IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            //eventsRepository.GetEvents(eventToAdd.Schedule).Returns(new[] { nonExclusiveIntersectingEvent });

            //ExclusiveSchedulePolicy exclusiveSchedulePolicy = new ExclusiveSchedulePolicy(eventsRepository) { EventToAdd = eventToAdd };
            //exclusiveSchedulePolicy.TryAddToRepository();

            //eventsRepository.Received(1).AddEvent(eventToAdd);
        }
    }
}
