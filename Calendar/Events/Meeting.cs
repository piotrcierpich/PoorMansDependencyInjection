namespace Calendar.Events
{
    class Meeting : CalendarEvent
    {
        //public override void AddToEventsRepository(IEventsRepository eventsRepository)
        //{
        //    throw new System.NotImplementedException();
        //}

        public string[] Pariticipants { get; set; }
    }
}