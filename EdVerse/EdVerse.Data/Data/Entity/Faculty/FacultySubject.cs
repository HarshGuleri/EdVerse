using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.People;

namespace EdVerse.Data.Data.Entity.Faculty
{
    public class FacultySubject : BaseEntity
    {
        // Faculty

        public int StaffId { get; set; }

        // Academic

        public int SubjectId { get; set; }

        public int SemesterId { get; set; }

        public int SectionId { get; set; }

        // Assignment

        public DateTime AssignedOn { get; set; }

        public bool IsClassTeacher { get; set; }

        // Navigation Properties

        public virtual Staff Staff { get; set; } = null!;

        public virtual Subject Subject { get; set; } = null!;

        public virtual Semester Semester { get; set; } = null!;

        public virtual Section Section { get; set; } = null!;
    }
}
