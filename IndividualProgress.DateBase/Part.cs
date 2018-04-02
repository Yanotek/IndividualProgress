using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Part
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? EventId { get; set; }
        public int? Place { get; set; }
        public int? Score { get; set; }

        public Event Event { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
