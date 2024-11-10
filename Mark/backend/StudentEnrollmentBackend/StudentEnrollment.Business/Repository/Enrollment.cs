using System;
using System.Collections.Generic;

namespace StudentEnrollment.Business.Repository
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } = null!;
        public string? Comments { get; set; }
    }
}
