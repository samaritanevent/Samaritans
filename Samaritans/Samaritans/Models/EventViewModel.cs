using Samaritans.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Samaritans.Models
{
    public class EventViewModel
    {
        public EventViewModel(Event e)
        {
            this.Name = e.Name;
            this.EventDate = e.EventDate;
            this.MaxAttendance = e.MaxAttendance;
            this.MinAttendance = e.MinAttendance;
            this.Purpose = e.Purpose;
        }

        public EventViewModel()
        {
        }

        [Display(Name = "Event Name")]
        public string Name { get; set; }

        [Display(Name = "Purpose of Event")]
        public string Purpose { get; set; }

        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Minimum Attendees")]
        public int MinAttendance { get; set; }

        [Display(Name = "Max Attendees")]
        public int MaxAttendance { get; set; }

        [Display(Name = "Organizer Name")]
        public string OrganizerName { get; set; }
    }
}