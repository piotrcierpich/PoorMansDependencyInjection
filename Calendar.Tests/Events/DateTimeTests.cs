using System;

using Calendar.Events;

using NUnit.Framework;

namespace Calendar.Tests.Events
{

    [TestFixture]
    class DateTimeTests
    {
        [Test]
        public void ShouldIntersectBeTrueWhenDateSpansEndIsGreaterThanOthersStart()
        {
            DateTime end1 = DateTime.Now.Add(TimeSpan.FromHours(1));
            DateTime start2 = DateTime.Now;
            DateSpan dateSpan1 = new DateSpan(DateTime.MinValue, end1);
            DateSpan dateSpan2 = new DateSpan(start2, DateTime.MaxValue);

            Assert.IsTrue(dateSpan1.IntersectWith(dateSpan2));
            Assert.IsTrue(dateSpan2.IntersectWith(dateSpan1));
        }

        [Test]
        public void ShouldIntersectsWithBeFalseWhenDatSpansEndIsLowerThanOthersStart()
        {
            DateTime end1 = DateTime.Now;
            DateTime start2 = DateTime.Now.Add(TimeSpan.FromHours(1));
            DateSpan dateSpan1 = new DateSpan(DateTime.MinValue, end1);
            DateSpan dateSpan2 = new DateSpan(start2, DateTime.MaxValue);

            Assert.IsFalse(dateSpan1.IntersectWith(dateSpan2));
            Assert.IsFalse(dateSpan2.IntersectWith(dateSpan1));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowWhenStartIsGreaterThanEnd()
        {
            DateTime endTime = DateTime.Now;
            DateTime startTime = endTime.AddMilliseconds(1);
            new DateSpan(startTime, endTime);
        }
    }
}
