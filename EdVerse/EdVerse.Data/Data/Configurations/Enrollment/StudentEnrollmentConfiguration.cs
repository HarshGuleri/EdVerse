using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Enrollment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Enrollment
{
    public class StudentEnrollmentConfiguration : IEntityTypeConfiguration<StudentEnrollment>
    {
        public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
        {
            // Table

            builder.ToTable("StudentEnrollments");

            // Primary Key

            builder.HasKey(se => se.Id);

            // Properties

            builder.Property(se => se.EnrollmentDate)
                   .IsRequired();

            builder.Property(se => se.EnrollmentStatus)
                   .IsRequired();

            builder.Property(se => se.Remarks)
                   .HasMaxLength(500);

            // Composite Index

            builder.HasIndex(se => new
            {
                se.StudentId,
                se.SemesterId
            }).IsUnique();

            // Relationships

            builder.HasOne(se => se.Student)
                   .WithMany(s => s.StudentEnrollments)
                   .HasForeignKey(se => se.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(se => se.AcademicBatch)
                   .WithMany()
                   .HasForeignKey(se => se.AcademicBatchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(se => se.Semester)
                   .WithMany(s => s.StudentEnrollments)
                   .HasForeignKey(se => se.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(se => se.Section)
                   .WithMany(sec => sec.StudentEnrollments)
                   .HasForeignKey(se => se.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
