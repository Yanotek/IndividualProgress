using System;
using System.Collections.Generic;

namespace IndividualProgress.DateBase
{
    public partial class Student
    {
        public Student()
        {
            Part = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int? GroupId { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Group Group { get; set; }
        public ICollection<Part> Part { get; set; }
    }
}
