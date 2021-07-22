using CodingEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Data
{
    public class EventData
    {
        // store events
        private static Dictionary<int, Event> Events = new Dictionary<int, Event>();

        // add events
        public static void Add(Event newEvent)
        {
            Events.Add(newEvent.ID, newEvent);
        }
        // retrieve events
        public static IEnumerable<Event> GetAll()
        {
            return Events.Values;
        }

        // retrieve single event
        public static Event GetByID(int id)
        {
            return Events[id];
        }

        // remove event
    }
}
