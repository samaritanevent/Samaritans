using Samaritans.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaritans.Models
{
	public class EventViewModel
	{
		private Event e;
		private AspNetUser currentUser;

		public EventViewModel(Event e, AspNetUser currentUser)
		{
			this.e = e;
			this.currentUser = currentUser;
		}

		public string Name
		{
			get { return e.Name; }
		}

		public string Purpose
		{
			get { return e.Purpose; }
		}

		public bool Obsolete
		{
			get
			{
				return IsFull || Done;
			}
		}

		public bool IsFull
		{
			get { return e.Participants.Count >= e.MaxAttendance; }
		}

		public bool Done
		{
			get	{ return DateTime.Now > e.EventDate; }
		}

		public bool IsHosting
		{
			get { return e.Organizer == currentUser; }
		}

		public bool IsAttending
		{
			get { return e.Participants.Any(p => p.User == currentUser); }
		}

		public string TimeDisplay
		{
			get
			{
				var now = DateTime.Now;
				var timeTil = e.EventDate - DateTime.Now;

				if (timeTil <= TimeSpan.Zero)
				{
					return "DONE";
				}
				else if (timeTil >= TimeSpan.FromDays(7))
				{
					return e.EventDate.ToString("dddd, MMMM d, h:mm tt");
				}
				else
				{
					return e.EventDate.ToString("dddd, h:mm tt");
				}
			}
		}

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

		public bool CapacityWarning
		{
			get
			{
				return IsFull || BelowCapacity;
			}
		}

		public bool BelowCapacity
		{
			get { return e.Participants.Count < e.MinAttendance; }
		}

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

		public int MinAttendance
		{
			get { return e.MinAttendance; }
		}

		public int MaxAttendance
		{
			get { return e.MaxAttendance; }
		}

		public string OrganizerName
		{
			get { return e.Organizer.UserName; }
		}
	}
}