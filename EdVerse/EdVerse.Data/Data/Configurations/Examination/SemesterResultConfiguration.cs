using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Examination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Examination
{
    public class SemesterResultConfiguration : IEntityTypeConfiguration<SemesterResult>
    {
        public void Configure(EntityTypeBuilder<SemesterResult> builder)
        {
            builder.ToTable("SemesterResults");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TotalMaximumMarks)
                   .HasPrecision(8, 2);

            builder.Property(x => x.TotalObtainedMarks)
                   .HasPrecision(8, 2);

            builder.Property(x => x.Percentage)
                   .HasPrecision(5, 2);

            builder.Property(x => x.Remarks)
                   .HasMaxLength(500);

            builder.HasIndex(x => x.StudentEnrollmentId)
                   .IsUnique();

            builder.HasOne(x => x.StudentEnrollment)
                   .WithOne(se => se.SemesterResult)
                   .HasForeignKey<SemesterResult>(x => x.StudentEnrollmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}