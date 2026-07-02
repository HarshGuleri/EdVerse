using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Academic
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table

            builder.ToTable("Courses");

            // Primary Key

            builder.HasKey(c => c.Id);

            // Properties

            builder.Property(c => c.CourseCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(c => c.CourseName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.DurationInYears)
                   .IsRequired();

            builder.Property(c => c.TotalSemesters)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            // Unique Index

            builder.HasIndex(c => c.CourseCode)
                   .IsUnique();

            // Relationships

            builder.HasMany(c => c.Departments)
                   .WithOne(d => d.Course)
                   .HasForeignKey(d => d.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.AcademicBatches)
                   .WithOne(b => b.Course)
                   .HasForeignKey(b => b.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}