using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;

namespace EdVerse.Data.Data.Entity.Examination
{
    public class ExamComponent : BaseEntity
    {
        public int ExamPatternId { get; set; }

        public string ComponentCode { get; set; } = string.Empty;

        public string ComponentName { get; set; } = string.Empty;

        public int MaximumMarks { get; set; }

        public int PassingMarks { get; set; }

        public decimal Weightage { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsMandatory { get; set; } = true;

        // Navigation

        public virtual ExamPattern ExamPattern { get; set; } = null!;

        public virtual ICollection<StudentMarks> StudentMarks { get; set; }
    = new HashSet<StudentMarks>();
    }
}
