using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Location
    {
        public Location()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
