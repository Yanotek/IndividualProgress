using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Event
    {
        public Event()
        {
            Part = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int DirectionId { get; set; }
        public int? LevelId { get; set; }
        public int? LocationId { get; set; }

        public Direction Direction { get; set; }
        public Level Level { get; set; }
        public Location Location { get; set; }
        public ICollection<Part> Part { get; set; }
    }
}
