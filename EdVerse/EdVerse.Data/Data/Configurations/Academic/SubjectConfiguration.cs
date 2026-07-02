using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Academic
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SubjectCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(s => s.SubjectName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.Credits)
                   .IsRequired();

            builder.Property(s => s.MaximumMarks)
                   .IsRequired();

            builder.Property(s => s.PassingMarks)
                   .IsRequired();

            builder.Property(s => s.IsPractical)
                   .IsRequired();

            builder.HasIndex(s => s.SubjectCode);

            builder.HasOne(s => s.Semester)
                   .WithMany(se => se.Subjects)
                   .HasForeignKey(s => s.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ExamPattern)
                   .WithMany(ep => ep.Subjects)
                   .HasForeignKey(s => s.ExamPatternId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(s => s.FacultySubjects)
                   .WithOne(fs => fs.Subject)
                   .HasForeignKey(fs => fs.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StudentMarks)
                   .WithOne(sm => sm.Subject)
                   .HasForeignKey(sm => sm.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
