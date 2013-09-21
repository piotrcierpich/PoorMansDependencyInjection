﻿using System;

using Calendar.Events;
using Calendar.UI;

using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests.UI
{
    [TestFixture]
    class AddMeetingOptionTests
    {
        [Test]
        public void ShouldHaveMAsOptionString()
        {
            StringAssert.AreEqualIgnoringCase("m", AddMeetingOption.AddMeetingOptionString);
        }

        [Test]
        public void ShouldMatchItsOptionString()
        {
            Func<CalendarEvent> meetingFactory = Substitute.For<Func<CalendarEvent>>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();

            AddMeetingOption addMeetingOption = new AddMeetingOption(meetingFactory, eventsRepository);
            bool result = addMeetingOption.MatchesString(AddMeetingOption.AddMeetingOptionString);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldCreateMeetingAndAddItToPlanner()
        {
            CalendarEvent meetingEvent = Substitute.For<CalendarEvent>();
            Func<CalendarEvent> meetingFactory = Substitute.For<Func<CalendarEvent>>();
            meetingFactory().Returns(meetingEvent);

            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();
            AddMeetingOption addMeetingOption = new AddMeetingOption(meetingFactory, eventsRepository);

            addMeetingOption.Run();

            eventsRepository.Received(1).AddEvent(meetingEvent);
        }
    }
}