using Samaritans.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Samaritans.Models.Event
{
    public class EventViewModel
    {
        private Data.Entities.Event e;
        private AspNetUser currentUser;

        public EventViewModel(Data.Entities.Event e, AspNetUser currentUser)
        {
            this.e = e;
            this.currentUser = currentUser;
        }

        public int Id
        {
            get { return e.Id; }
        }

        [Display(Name = "Event Name")]
        public string Name
        {
            get { return e.Name; }
        }

        [Display(Name = "Purpose of Event")]
        public string Purpose
        {
            get { return e.Purpose; }
        }

        [Display(Name = "Event is Outdated")]
        public bool Obsolete
        {
            get
            {
                return IsFull || Done;
            }
        }

        [Display(Name = "Event is Full")]
        public bool IsFull
        {
            get { return e.Participants.Count >= e.MaxAttendance; }
        }

        [Display(Name = "Event has Concluded")]
        public bool Done
        {
            get { return DateTime.Now > e.EventDate; }
        }

        public bool IsHosting
        {
            get { return e.Organizer == currentUser; }
        }

        public bool IsAttending
        {
            get { return e.Participants.Any(p => p.User == currentUser); }
        }

        [Display(Name = "Time to Event")]
        public string TimeDisplay
        {
            get
            {
                if (Done)
                {
                    return "DONE";
                }

                var currentDate = DateTime.Now.Date;
                var eventDate = e.EventDate.Date;
                var daysApart = eventDate - currentDate;

                if (daysApart >= TimeSpan.FromDays(7))
                {
                    return e.EventDate.ToString("dddd, MMMM d, h:mm tt");
                }
                else if (daysApart >= TimeSpan.FromDays(1))
                {
                    return e.EventDate.ToString("dddd, h:mm tt");
                }
                else
                {
                    return e.EventDate.ToString("TODAY, h:mm tt");
                }
            }
        }

        [Display(Name = "Attendance")]
        public string AttendanceDisplay
        {
            get
            {
                if (IsHosting)
                {
                    return "You are hosting this event";
                }
                else if (IsAttending)
                {
                    return "You are attending this event";
                }
                else
                {
                    return null;
                }
            }
        }

        [Display(Name = "Event Capacity")]
        public bool CapacityWarning
        {
            get
            {
                return IsFull || BelowCapacity;
            }
        }

        [Display(Name = "Event Capacity")]
        public bool BelowCapacity
        {
            get { return e.Participants.Count < e.MinAttendance; }
        }

        [Display(Name = "Attendance")]
        public string Attendance
        {
            get
            {
                if (BelowCapacity)
                {
                    var pattern = "{0} of {1} volunteers";
                    return string.Format(pattern, e.Participants.Count, e.MaxAttendance);
                }
                else if (IsFull)
                {
                    return string.Format("FULL, {0} volunteers", e.Participants.Count);
                }
                else
                {
                    return string.Format("{0} volunteers", e.Participants.Count);
                }
            }
        }

        [Display(Name = "Minimum Attendance")]
        public int MinAttendance
        {
            get { return e.MinAttendance; }
        }

        [Display(Name = "Max Attendance")]
        public int MaxAttendance
        {
            get { return e.MaxAttendance; }
        }

        [Display(Name = "Organizer Name")]
        public string OrganizerName
        {
            get { return e.Organizer.UserName; }
        }
    }
}