using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Sphere
    {
        public Sphere()
        {
            Direction = new HashSet<Direction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Direction> Direction { get; set; }
    }
}
