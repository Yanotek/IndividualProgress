using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Direction
    {
        public Direction()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public int SphereId { get; set; }
        public string Description { get; set; }

        public Sphere Sphere { get; set; }
        public ICollection<Event> Event { get; set; }
    }
}
