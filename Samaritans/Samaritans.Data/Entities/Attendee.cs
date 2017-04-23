using System.Collections.Generic;

namespace Samaritans.Data.Entities
{
    public class Attendee
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int EventId { get; set; }

        public int ResourceId { get; set; }

        public decimal Quantity { get; set; }

        public virtual AspNetUser User { get; set; }

        public virtual Event Event { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
