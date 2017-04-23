using System;

namespace Samaritans.Data.Entities
{
    public class Resource
    {
        public int Id { get; set; }

        public int EventId { get; set; }

        public decimal Quantity { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Event Event { get; set; }

    }
}
