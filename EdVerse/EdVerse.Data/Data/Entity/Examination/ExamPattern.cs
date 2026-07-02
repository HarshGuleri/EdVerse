using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Base;

namespace EdVerse.Data.Data.Entity.Examination
{
    public class ExamPattern : BaseEntity
    {
        public string PatternCode { get; set; } = string.Empty;

        public string PatternName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation Properties

        public virtual ICollection<ExamComponent> ExamComponents { get; set; }
            = new HashSet<ExamComponent>();

        // Subjects using this Exam Pattern

        public virtual ICollection<Subject> Subjects { get; set; }
            = new HashSet<Subject>();

        // Semesters using this as Default Pattern

        public virtual ICollection<Semester> Semesters { get; set; }
            = new HashSet<Semester>();
    }
}
