using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Entity.People;
namespace EdVerse.Data.Data.Entity.Academic
{
    public class Department : BaseEntity
    {
        public int CourseId { get; set; }

        public string DepartmentCode { get; set; } = string.Empty;

        public string DepartmentName { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Navigation Properties

        public virtual Course Course { get; set; } = null!;

        // Add Later

        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public virtual ICollection<Staff> StaffMembers { get; set; } = new HashSet<Staff>();
    }
}
