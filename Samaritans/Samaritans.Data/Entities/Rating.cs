using System;

namespace Samaritans.Data.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AttendenceId { get; set; }

        public double Points { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual Attendence Attendence { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
