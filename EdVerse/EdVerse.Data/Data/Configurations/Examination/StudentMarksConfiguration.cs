using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Examination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Examination
{
    public class StudentMarksConfiguration : IEntityTypeConfiguration<StudentMarks>
    {
        public void Configure(EntityTypeBuilder<StudentMarks> builder)
        {
            builder.ToTable("StudentMarks");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaximumMarks)
                   .IsRequired();

            builder.Property(x => x.PassingMarks)
                   .IsRequired();

            builder.Property(x => x.ObtainedMarks)
                   .HasPrecision(6, 2);

            builder.Property(x => x.AttemptNumber)
                   .IsRequired();

            builder.Property(x => x.Remarks)
                   .HasMaxLength(500);

            builder.HasIndex(x => new
            {
                x.StudentEnrollmentId,
                x.SubjectId,
                x.ExamComponentId,
                x.AttemptNumber
            }).IsUnique();

            builder.HasOne(x => x.StudentEnrollment)
                   .WithMany(se => se.StudentMarks)
                   .HasForeignKey(x => x.StudentEnrollmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Subject)
                   .WithMany(s => s.StudentMarks)
                   .HasForeignKey(x => x.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ExamComponent)
                   .WithMany(ec => ec.StudentMarks)
                   .HasForeignKey(x => x.ExamComponentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}