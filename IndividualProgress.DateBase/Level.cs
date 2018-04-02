using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Level
    {
        public Level()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
