using System;
using System.Collections.Generic;
using System.Text;
using EdVerse.Data.Data.Entity.Base;

namespace EdVerse.Data.Data.Entity.Academic
{
    public class Course : BaseEntity
    {
        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public int DurationInYears { get; set; }

        public int TotalSemesters { get; set; }

        public string? Description { get; set; }

        // Navigation Properties

        public virtual ICollection<AcademicBatch> AcademicBatches { get; set; }
            = new HashSet<AcademicBatch>();

        public virtual ICollection<Department> Departments { get; set; }
            = new HashSet<Department>();
    }
}