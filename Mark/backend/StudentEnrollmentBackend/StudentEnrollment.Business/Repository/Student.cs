using System;
using System.Collections.Generic;

namespace StudentEnrollment.Business.Repository
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Gender { get; set; } = null!;
        public string? Address { get; set; }
    }
}
