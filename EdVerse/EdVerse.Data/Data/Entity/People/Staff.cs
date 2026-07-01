using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Enums;
using EdVerse.Data.Data.Identity;
using EdVerse.Data.Data.Entity.Faculty;

namespace EdVerse.Data.Data.Entity.People
{
    public class Staff : BaseEntity
    {
        // Identity Relation

        public string ApplicationUserId { get; set; } = string.Empty;

        // Academic Relation

        public int DepartmentId { get; set; }

        // Staff Information

        public string EmployeeCode { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string? BloodGroup { get; set; }

        public DateTime JoiningDate { get; set; }

        public StaffType StaffType { get; set; }

        public string? Qualification { get; set; }

        public decimal? ExperienceInYears { get; set; }

        // Contact

        public string? Address { get; set; }

        public string? ProfilePhoto { get; set; }

        // Navigation Properties

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public virtual Department Department { get; set; } = null!;

        // Add Later

        public virtual ICollection<FacultySubject> FacultySubjects { get; set; }
            = new HashSet<FacultySubject>();
    }
}
