using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;

namespace EdVerse.Data.Data.Entity.Examination
{
    public class ExamPattern : BaseEntity
    {
        public string PatternCode { get; set; } = string.Empty;

        public string PatternName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation

        public virtual ICollection<ExamComponent> ExamComponents { get; set; }
            = new HashSet<ExamComponent>();
    }
}
