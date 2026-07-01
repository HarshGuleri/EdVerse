using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Base;
using EdVerse.Data.Data.Enums;
using EdVerse.Data.Data.Identity;
using EdVerse.Data.Data.Entity.Enrollment;

namespace EdVerse.Data.Data.Entity.People
{
    public class Student : BaseEntity
    {
        // Identity Relation
        public string ApplicationUserId { get; set; } = string.Empty;

        // Academic Information
        public int CourseId { get; set; }

        public int DepartmentId { get; set; }

        public int AcademicBatchId { get; set; }

        // Student Information
        public string EnrollmentNumber { get; set; } = string.Empty;

        public DateTime AdmissionDate { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string? MiddleName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string? BloodGroup { get; set; }

        // Family Information
        public string FatherName { get; set; } = string.Empty;

        public string MotherName { get; set; } = string.Empty;

        // Contact
        public string? Address { get; set; }

        public string? ProfilePhoto { get; set; }

        // Navigation Properties

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public virtual Course Course { get; set; } = null!;

        public virtual Department Department { get; set; } = null!;

        public virtual AcademicBatch AcademicBatch { get; set; } = null!;

        // Add Later
        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }
            = new HashSet<StudentEnrollment>();

        // public virtual ICollection<StudentMarks> StudentMarks { get; set; }
        //     = new HashSet<StudentMarks>();

        // public virtual ICollection<Attendance> Attendances { get; set; }
        //     = new HashSet<Attendance>();
    }
}