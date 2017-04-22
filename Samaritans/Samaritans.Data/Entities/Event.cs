using System;
using System.Collections.Generic;

namespace Samaritans.Data.Entities
{
    public class Event
    {
        public Event()
        {
            Attendences = new HashSet<Attendence>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public virtual ICollection<Attendence> Attendences { get; set; }

    }
}
