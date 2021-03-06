﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using Calendar.Events;

namespace Calendar.DataAccess
{
    class EventsRepository : IEventsRepository
    {
        private readonly BinaryFormatter binaryFormatter = new BinaryFormatter();
        private readonly string fileName;

        public EventsRepository(string fileName)
        {
            this.fileName = fileName;
        }

        public ICalendarEvent[] GetEvents(DateSpan schedule)
        {
            try
            {
                IEnumerable<ICalendarEvent> allEvents = TryReadingCalendarEvents();
                return allEvents.Where(e => e.Schedule.IntersectWith(schedule))
                                .ToArray();
            }
            catch (Exception)
            {
                return new ICalendarEvent[0];
            }
        }

        private IEnumerable<ICalendarEvent> TryReadingCalendarEvents()
        {
            using (Stream s = File.OpenRead(fileName))
            {
                return (ICalendarEvent[])binaryFormatter.Deserialize(s);
            }
        }

        public void AddEvent(ICalendarEvent eventToAdd)
        {
            IList<ICalendarEvent> allEvents = GetEvents(DateSpan.Max).ToList();
            allEvents.Add(eventToAdd);

            using (Stream s = File.OpenWrite(fileName))
            {
                binaryFormatter.Serialize(s, allEvents.ToArray());
            }
        }
    }
}
