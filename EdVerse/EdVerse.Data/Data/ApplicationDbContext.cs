using EdVerse.Data.Data.Entity.Academic;
using EdVerse.Data.Data.Entity.People;
using EdVerse.Data.Data.Entity.Enrollment;
using EdVerse.Data.Data.Entity.Faculty;
using EdVerse.Data.Data.Entity.Examination;
using EdVerse.Data.Data.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdVerse.Data.Data
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext
        (
            DbContextOptions<ApplicationDbContext> options
        )
            : base(options)
        {

        }
        #region Academic

        public DbSet<Course> Courses => Set<Course>();

        public DbSet<Department> Departments => Set<Department>();

        public DbSet<AcademicBatch> AcademicBatches => Set<AcademicBatch>();

        public DbSet<Semester> Semesters => Set<Semester>();

        public DbSet<Section> Sections => Set<Section>();

        public DbSet<Subject> Subjects => Set<Subject>();

        #endregion


        #region People

        public DbSet<Student> Students => Set<Student>();

        public DbSet<Staff> Staffs => Set<Staff>();

        #endregion


        #region Enrollment

        public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();

        #endregion


        #region Faculty

        public DbSet<FacultySubject> FacultySubjects => Set<FacultySubject>();

        #endregion


        #region Examination

        public DbSet<ExamPattern> ExamPatterns => Set<ExamPattern>();

        public DbSet<ExamComponent> ExamComponents => Set<ExamComponent>();

        public DbSet<StudentMarks> StudentMarks => Set<StudentMarks>();

        public DbSet<SemesterResult> SemesterResults => Set<SemesterResult>();

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Fluent API configurations yaha aayengi.
        }
    }
}