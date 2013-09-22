using System;

using Calendar.Events;
using Calendar.UI;

using NSubstitute;

using NUnit.Framework;

namespace Calendar.Tests.UI
{
    [TestFixture]
    class AddTodoOptionTests
    {
        [Test]
        public void ShouldHaveAAsOptionString()
        {
            StringAssert.AreEqualIgnoringCase("a", AddTodoOption.AddToDoOptionString);
        }

        [Test]
        public void ShouldMatchItsOptionAsString()
        {
            Func<CalendarEventBase> todoEventFactory = Substitute.For<Func<CalendarEventBase>>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();

            AddTodoOption addTodoOption = new AddTodoOption(todoEventFactory, eventsRepository);
            bool result = addTodoOption.MatchesString(AddTodoOption.AddToDoOptionString);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldCreateTodoAndAddItToPlanner()
        {
            ICalendarEvent todoEvent = Substitute.For<ICalendarEvent>();
            Func<ICalendarEvent> todoEventFactory = Substitute.For<Func<ICalendarEvent>>();
            todoEventFactory().Returns(todoEvent);

            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();

            AddTodoOption addTodoOption = new AddTodoOption(todoEventFactory, eventsRepository);
            addTodoOption.Run();
            
            eventsRepository.Received(1).AddEvent(todoEvent);
        }
    }
}
