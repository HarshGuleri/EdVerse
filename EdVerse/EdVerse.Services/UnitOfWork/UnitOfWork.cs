using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data;
using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.Enrollment;
using EdVerse.Data.Data.Entity.Examination;
using EdVerse.Data.Data.Entity.Faculty;
using EdVerse.Data.Data.Entity.People;

using EdVerse.Interfaces.Repositories;
using EdVerse.Interfaces.UnitOfWork;

using EdVerse.Services.Repositories;

namespace EdVerse.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        // Academic

        public IRepository<Course> Courses { get; }

        public IRepository<Department> Departments { get; }

        public IRepository<AcademicBatch> AcademicBatches { get; }

        public IRepository<Semester> Semesters { get; }

        public IRepository<Section> Sections { get; }

        public IRepository<Subject> Subjects { get; }

        // People

        public IRepository<Student> Students { get; }

        public IRepository<Staff> Staffs { get; }

        // Enrollment

        public IRepository<StudentEnrollment> StudentEnrollments { get; }

        // Faculty

        public IRepository<FacultySubject> FacultySubjects { get; }

        // Examination

        public IRepository<ExamPattern> ExamPatterns { get; }

        public IRepository<ExamComponent> ExamComponents { get; }

        public IRepository<StudentMarks> StudentMarks { get; }

        public IRepository<SemesterResult> SemesterResults { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            // Academic

            Courses = new Repository<Course>(_context);

            Departments = new Repository<Department>(_context);

            AcademicBatches = new Repository<AcademicBatch>(_context);

            Semesters = new Repository<Semester>(_context);

            Sections = new Repository<Section>(_context);

            Subjects = new Repository<Subject>(_context);

            // People

            Students = new Repository<Student>(_context);

            Staffs = new Repository<Staff>(_context);

            // Enrollment

            StudentEnrollments = new Repository<StudentEnrollment>(_context);

            // Faculty

            FacultySubjects = new Repository<FacultySubject>(_context);

            // Examination

            ExamPatterns = new Repository<ExamPattern>(_context);

            ExamComponents = new Repository<ExamComponent>(_context);

            StudentMarks = new Repository<StudentMarks>(_context);

            SemesterResults = new Repository<SemesterResult>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
