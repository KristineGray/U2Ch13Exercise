using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.Models
{
    public class Event
    {
        private static int nextID = 1;
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; }

        public Event()
        {
            ID = nextID;
            nextID++;
        }
        public Event(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            return obj is Event @event && ID == @event.ID;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}
