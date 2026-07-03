using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.People
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Table

            builder.ToTable("Students");

            // Primary Key

            builder.HasKey(s => s.Id);

            // Properties

            builder.Property(s => s.EnrollmentNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.MiddleName)
                   .HasMaxLength(100);

            builder.Property(s => s.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.FatherName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.MotherName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.BloodGroup)
                   .HasMaxLength(10);

            builder.Property(s => s.Address)
                   .HasMaxLength(500);

            builder.Property(s => s.ProfilePhoto)
                   .HasMaxLength(500);

            builder.Property(s => s.AdmissionDate)
                   .IsRequired();

            // Indexes

            builder.HasIndex(s => s.EnrollmentNumber)
                   .IsUnique();

            // Relationships

            builder.HasOne(s => s.ApplicationUser)
                   .WithOne()
                   .HasForeignKey<Student>(s => s.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Course)
                   .WithMany()
                   .HasForeignKey(s => s.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Department)
                   .WithMany(d => d.Students)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.AcademicBatch)
                   .WithMany(ab => ab.Students)
                   .HasForeignKey(s => s.AcademicBatchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StudentEnrollments)
                   .WithOne(se => se.Student)
                   .HasForeignKey(se => se.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}