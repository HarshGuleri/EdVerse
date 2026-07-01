using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Enums;
using EdVerse.Data.Data.Entity.Enrollment;
using EdVerse.Data.Data.Entity.Examination;
namespace EdVerse.Data.Data.Entity.Academic
{
    public class Semester : BaseEntity
    {
        public int AcademicBatchId { get; set; }

        public int SemesterNumber { get; set; }

        public SemesterType SemesterType { get; set; }

        public string AcademicYear { get; set; } = string.Empty;

        public int? DefaultExamPatternId { get; set; }
        // Example : 2026-2027

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Navigation Properties

        public virtual AcademicBatch AcademicBatch { get; set; } = null!;

        public virtual ICollection<Section> Sections { get; set; }
            = new HashSet<Section>();

        public virtual ICollection<Subject> Subjects { get; set; }
            = new HashSet<Subject>();

        public virtual ExamPattern? DefaultExamPattern { get; set; }

        // Add later
        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new HashSet<StudentEnrollment>();
    }
}
