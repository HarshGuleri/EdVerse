using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.Enrollment;

namespace EdVerse.Data.Data.Entity.Examination
{
    public class SemesterResult : BaseEntity
    {
        // Academic Reference

        public int StudentEnrollmentId { get; set; }

        // Summary

        public decimal TotalMaximumMarks { get; set; }

        public decimal TotalObtainedMarks { get; set; }

        public decimal Percentage { get; set; }

        // Overall Status

        public bool IsPassed { get; set; }

        public int BacklogCount { get; set; }

        public bool HasBacklog { get; set; }

        // Attempts

        public int AttemptNumber { get; set; } = 1;

        // Publication

        public bool IsPublished { get; set; } = false;

        public DateTime? PublishedOn { get; set; }

        public string? Remarks { get; set; }

        // Navigation

        public virtual StudentEnrollment StudentEnrollment { get; set; } = null!;
    }
}
