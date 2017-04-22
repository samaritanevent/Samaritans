using System;
using System.Collections.Generic;

namespace Samaritans.Data.Entities
{
    public class Attendence
    {
        public Attendence()
        {
            Availabilities = new HashSet<Availability>();
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public bool Attended { get; set; }

        public string JobName { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Rating Rating { get; set; }

        public virtual ICollection<Availability> Availabilities { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}
