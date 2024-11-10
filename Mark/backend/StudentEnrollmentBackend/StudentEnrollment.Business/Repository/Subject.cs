using System;
using System.Collections.Generic;

namespace StudentEnrollment.Business.Repository
{
    public partial class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CourseId { get; set; }

        public virtual Course Course { get; set; } = null!;
    }
}
