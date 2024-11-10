using System;
using System.Collections.Generic;

namespace StudentEnrollment.Business.Repository
{
    public partial class Course
    {
        public Course()
        {
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Fees { get; set; }
        public string LocationAddress { get; set; } = null!;
        public string ContactPerson { get; set; } = null!;

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
