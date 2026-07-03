using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.Examination;
using EdVerse.Data.Data.Entity.People;
using EdVerse.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdVerse.Data.Data.Entity.Enrollment
{
    public class StudentEnrollment : BaseEntity
    {
        // Student Information

        public int StudentId { get; set; }

        // Academic Information

        public int AcademicBatchId { get; set; }

        public int SemesterId { get; set; }

        public int SectionId { get; set; }

        // Enrollment Information

        public DateTime EnrollmentDate { get; set; }

        public EnrollmentStatus EnrollmentStatus { get; set; }

        public string? Remarks { get; set; }

        // Navigation Properties

        public virtual Student Student { get; set; } = null!;

        public virtual AcademicBatch AcademicBatch { get; set; } = null!;

        public virtual Semester Semester { get; set; } = null!;

        public virtual Section Section { get; set; } = null!;

        public virtual ICollection<StudentMarks> StudentMarks { get; set; }
    = new HashSet<StudentMarks>();

        public virtual SemesterResult? SemesterResult { get; set; }
    }
}
