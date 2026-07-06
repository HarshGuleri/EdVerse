using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Enrollment;
using EdVerse.Data.Data.Entity.Examination;
using EdVerse.Data.Data.Entity.Faculty;
using EdVerse.Data.Data.Entity.People;
using EdVerse.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdVerse.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Academic
        IRepository<Course> Courses { get; }
        IRepository<Department> Departments { get; }
        IRepository<AcademicBatch> AcademicBatches { get; }
        IRepository<Semester> Semesters { get; }
        IRepository<Section> Sections { get; }
        IRepository<Subject> Subjects { get; }

        // People
        IRepository<Student> Students { get; }
        IRepository<Staff> Staffs { get; }

        // Enrollment
        IRepository<StudentEnrollment> StudentEnrollments { get; }

        // Faculty
        IRepository<FacultySubject> FacultySubjects { get; }

        // Examination
        IRepository<ExamPattern> ExamPatterns { get; }
        IRepository<ExamComponent> ExamComponents { get; }
        IRepository<StudentMarks> StudentMarks { get; }
        IRepository<SemesterResult> SemesterResults { get; }

        Task<int> SaveChangesAsync();
    }
}
