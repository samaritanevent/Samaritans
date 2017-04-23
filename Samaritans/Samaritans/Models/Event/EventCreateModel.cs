using System;

namespace Samaritans.Models.Event
{
    public class EventCreateModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Purpose { get; set; }

        public int MinAttendance { get; set; }

        public int MaxAttendance { get; set; }

        public string OganizerId { get; set; }

        public DateTime EventDate { get; set; }
    }
}
