using System;
using System.Collections.Generic;
using System.Text;
using EdVerse.Data.Data.Entity.Enrollment;
using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.Faculty;

namespace EdVerse.Data.Data.Entity.Academic
{
    public class Section : BaseEntity
    {
        public int SemesterId { get; set; }

        public string SectionName { get; set; } = string.Empty;
        // A, B, C

        public int Capacity { get; set; }

        // Navigation Properties

        public virtual Semester Semester { get; set; } = null!;

        // Add later
        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
            = new HashSet<StudentEnrollment>();
        public virtual ICollection<FacultySubject> FacultySubjects { get; set; }
            = new HashSet<FacultySubject>();
    }
}
