using System;
using System.Collections.Generic;

namespace Samaritans.Data.Entities
{
    public class Event
    {
        public Event()
        {
            Resources = new HashSet<Resource>();
            Users = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }

        public string OrganizerId { get; set; }

        public string Name { get; set; }

        public DateTime EventDate { get; set; }

        public AspNetUser Organizer { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}
