using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.Enrollment;

namespace EdVerse.Data.Data.Entity.Examination
{
    public class StudentMarks : BaseEntity
    {
        // Student & Academic References

        public int StudentEnrollmentId { get; set; }

        public int SubjectId { get; set; }

        public int ExamComponentId { get; set; }

        // Marks Snapshot

        public int MaximumMarks { get; set; }

        public int PassingMarks { get; set; }

        public decimal ObtainedMarks { get; set; }

        public int AttemptNumber { get; set; } = 1;

        // Status

        public bool IsAbsent { get; set; } = false;

        public bool IsPublished { get; set; } = false;

        public string? Remarks { get; set; }

        // Navigation Properties

        public virtual StudentEnrollment StudentEnrollment { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;

        public virtual ExamComponent ExamComponent { get; set; } = null!;
    }
}
