using System;
using System.ComponentModel.DataAnnotations;
namespace Samaritans.Models.Event
{
    public class EventListModel
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
        public string OganizerId { get; set; }

		[Display(Name = "IsOrganizer")]
		public bool IsOrganizing { get; set; }

        [Display(Name = "Day of Event")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Day of Event")]
        public string EventDateDisplay => $"{EventDate:MM/dd/yyyy}";

        [Display(Name = "Organizer")]
        public string OrganizerName { get; set; }

        [Display(Name = "Distance from User")]
        public decimal DistanceFromUser { get; set; }
    }
}
