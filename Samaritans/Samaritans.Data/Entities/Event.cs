using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Samaritans.Data.Entities
{
    public class Event
    {
        public Event()
        {
            Participants = new HashSet<Attendee>();
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        [Required]
        public string OrganizerId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Purpose { get; set; }

        public int MinAttendance { get; set; }
        public int MaxAttendance { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public AspNetUser Organizer { get; set; }

        public virtual ICollection<Attendee> Participants { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
