using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.Faculty;
using EdVerse.Data.Data.Entity.Examination;

namespace EdVerse.Data.Data.Entity.Academic
{
    public class Subject : BaseEntity
    {
        public int SemesterId { get; set; }

        public string SubjectCode { get; set; } = string.Empty;

        public string SubjectName { get; set; } = string.Empty;

        public int Credits { get; set; }

        public int MaximumMarks { get; set; }

        public int PassingMarks { get; set; }

        public bool IsPractical { get; set; }

        public int? ExamPatternId { get; set; }

        // Navigation Properties

        public virtual Semester Semester { get; set; } = null!;

        // Add later

        public virtual ICollection<FacultySubject> FacultySubjects { get; set; }
            = new HashSet<FacultySubject>();

        public virtual ExamPattern? ExamPattern { get; set; }

        public virtual ICollection<StudentMarks> StudentMarks { get; set; }
            = new HashSet<StudentMarks>();
    }
}
