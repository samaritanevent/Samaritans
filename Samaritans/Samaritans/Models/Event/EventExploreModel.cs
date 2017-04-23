using System;
using System.Collections.Generic;

namespace Samaritans.Models.Event
{
    public class EventExploreModel
    {
        public EventExploreModel()
        {
            Events = new List<EventListModel>();
        }

        public DateTime CurrentOffset { get; set; }

        public List<EventListModel> Events { get; set; }
    }
}