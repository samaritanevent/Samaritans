using System.Collections.Generic;

namespace Samaritans.Data.Entities
{
    public class Attendee
    {
        public Attendee()
        {
            Users = new HashSet<AspNetUser>();
            Events = new HashSet<Event>();
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public int EventId { get; set; }

        public int ResourceId { get; set; }

        public decimal Quantity { get; set; }

        public virtual ICollection<AspNetUser> Users { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
