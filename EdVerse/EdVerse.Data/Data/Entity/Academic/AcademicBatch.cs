using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.People;
namespace EdVerse.Data.Data.Entity.Academic
{
    public class AcademicBatch : BaseEntity
    {
        public int CourseId { get; set; }

        public int BatchYear { get; set; }          // 2026

        public int StartYear { get; set; }          // 2026

        public int EndYear { get; set; }            // 2029

        public string BatchName { get; set; } = string.Empty;
        // Example : BCA 2026-2029

        // Navigation Properties

        public virtual Course Course { get; set; } = null!;

        public virtual ICollection<Semester> Semesters { get; set; }
            = new HashSet<Semester>();

        public virtual ICollection<Student> Students { get; set; }
            = new HashSet<Student>();
    }
}
