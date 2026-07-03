using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Faculty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Faculty
{
    public class FacultySubjectConfiguration : IEntityTypeConfiguration<FacultySubject>
    {
        public void Configure(EntityTypeBuilder<FacultySubject> builder)
        {
            // Table

            builder.ToTable("FacultySubjects");

            // Primary Key

            builder.HasKey(fs => fs.Id);

            // Properties

            builder.Property(fs => fs.AssignedOn)
                   .IsRequired();

            builder.Property(fs => fs.IsClassTeacher)
                   .IsRequired();

            // Composite Index

            builder.HasIndex(fs => new
            {
                fs.StaffId,
                fs.SubjectId,
                fs.SemesterId,
                fs.SectionId
            }).IsUnique();

            // Relationships

            builder.HasOne(fs => fs.Staff)
                   .WithMany(s => s.FacultySubjects)
                   .HasForeignKey(fs => fs.StaffId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fs => fs.Subject)
                   .WithMany(s => s.FacultySubjects)
                   .HasForeignKey(fs => fs.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fs => fs.Semester)
                   .WithMany()
                   .HasForeignKey(fs => fs.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(fs => fs.Section)
                   .WithMany(s => s.FacultySubjects)
                   .HasForeignKey(fs => fs.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
