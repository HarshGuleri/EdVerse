using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Academic
{
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            // Table

            builder.ToTable("Semesters");

            // Primary Key

            builder.HasKey(s => s.Id);

            // Properties

            builder.Property(s => s.SemesterNumber)
                   .IsRequired();

            builder.Property(s => s.SemesterType)
                   .IsRequired();

            builder.Property(s => s.AcademicYear)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.StartDate)
                   .IsRequired();

            builder.Property(s => s.EndDate)
                   .IsRequired();

            // Relationships

            builder.HasOne(s => s.AcademicBatch)
                   .WithMany(ab => ab.Semesters)
                   .HasForeignKey(s => s.AcademicBatchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Sections)
                   .WithOne(sec => sec.Semester)
                   .HasForeignKey(sec => sec.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.Subjects)
                   .WithOne(sub => sub.Semester)
                   .HasForeignKey(sub => sub.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StudentEnrollments)
                   .WithOne(se => se.Semester)
                   .HasForeignKey(se => se.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.DefaultExamPattern)
                   .WithMany(ep => ep.Semesters)
                   .HasForeignKey(s => s.DefaultExamPatternId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
