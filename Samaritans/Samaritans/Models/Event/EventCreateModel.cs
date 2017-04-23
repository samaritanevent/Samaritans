using System;
using System.ComponentModel.DataAnnotations;
namespace Samaritans.Models.Event
{
    public class EventCreateModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Purpose")]
        public string Purpose { get; set; }

        [Display(Name = "Min Attendance")]
        public int MinAttendance { get; set; }

        [Display(Name = "Max Attendance")]
        public int MaxAttendance { get; set; }

        [Display(Name = "Organizer")]
        public string OrganizerId { get; set; }

        [Display(Name = "Day of Event")]
        public DateTime EventDate { get; set; }
    }
}
