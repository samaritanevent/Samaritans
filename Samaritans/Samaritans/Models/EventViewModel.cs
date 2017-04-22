using Samaritans.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Samaritans.Models
{
	public class EventViewModel
	{
		private Event e { get; set; }

		public EventViewModel(Event e)
		{
			this.e = e;
		}

		public string Name
		{
			get { return e.Name; }
		}

		public string Purpose
		{
			get { return e.Purpose; }
		}

		public DateTime EventDate
		{
			get { return e.EventDate; }
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