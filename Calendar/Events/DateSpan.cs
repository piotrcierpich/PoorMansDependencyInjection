using System;

namespace Calendar.Events
{
    public sealed class DateSpan
    {
        public static readonly DateSpan Max = new DateSpan(DateTime.MinValue, DateTime.MaxValue);
        private readonly DateTime startTime;
        private readonly DateTime endTime;

        public DateSpan(DateTime startTime, DateTime endTime)
        {
            if(endTime < startTime)
                throw new ArgumentException("End time cannot be lower than start time");

            this.startTime = startTime;
            this.endTime = endTime;
        }

        public bool IntersectWith(DateSpan other)
        {
            return endTime > other.startTime && startTime < other.endTime;
        }

        public DateTime StartTime
        {
            get { return startTime; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
        }

        public override bool Equals(object obj)
        {
            if ((obj == null || (!(obj is DateSpan))))
            {
                return false;
            }

            DateSpan other = (DateSpan)obj;
            return startTime.Equals(other.startTime) && endTime.Equals(other.endTime);
        }

        public override int GetHashCode()
        {
            return startTime.GetHashCode() | startTime.GetHashCode();
        }
    }
}