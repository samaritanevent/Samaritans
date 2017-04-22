using System.Collections.Generic;

namespace Samaritans.Data.Entities
{
    public class Availability
    {
        public Availability()
        {
            Attendences = new HashSet<Attendence>();
        }

        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Attendence> Attendences { get; set; }

        public virtual AspNetUser User { get; set; }
    }
}
