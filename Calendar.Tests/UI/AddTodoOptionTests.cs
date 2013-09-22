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
            Func<DateSpan, string, Todo> todoEventFactory = Substitute.For<Func<DateSpan, string, Todo>>();
            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();

            AddTodoOption addTodoOption = new AddTodoOption(todoEventFactory, eventsRepository);
            bool result = addTodoOption.MatchesString(AddTodoOption.AddToDoOptionString);
            Assert.IsTrue(result);
        }

        [Test]
        [Ignore("ignore until implement TextReader dependency injection into AddTodoOption replacing Console.Readline")]
        public void ShouldCreateTodoAndAddItToPlanner()
        {
            Todo todoEvent = new Todo(DateSpan.Max, string.Empty, null);
            Func<DateSpan, string, Todo> todoEventFactory = Substitute.For<Func<DateSpan, string, Todo>>();
            todoEventFactory(Arg.Any<DateSpan>(), Arg.Any<string>()).Returns(todoEvent);

            IEventsRepository eventsRepository = Substitute.For<IEventsRepository>();

            AddTodoOption addTodoOption = new AddTodoOption(todoEventFactory, eventsRepository);
            addTodoOption.Run();
            
            eventsRepository.Received(1).AddEvent(todoEvent);
        }
    }
}
