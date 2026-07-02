using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Academic
{
    public class AcademicBatchConfiguration : IEntityTypeConfiguration<AcademicBatch>
    {
        public void Configure(EntityTypeBuilder<AcademicBatch> builder)
        {
            // Table

            builder.ToTable("AcademicBatches");

            // Primary Key

            builder.HasKey(ab => ab.Id);

            // Properties

            builder.Property(ab => ab.BatchYear)
                   .IsRequired();

            builder.Property(ab => ab.StartYear)
                   .IsRequired();

            builder.Property(ab => ab.EndYear)
                   .IsRequired();

            builder.Property(ab => ab.BatchName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Indexes

            builder.HasIndex(ab => ab.BatchName);

            // Relationships

            builder.HasOne(ab => ab.Course)
                   .WithMany(c => c.AcademicBatches)
                   .HasForeignKey(ab => ab.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ab => ab.Semesters)
                   .WithOne(s => s.AcademicBatch)
                   .HasForeignKey(s => s.AcademicBatchId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ab => ab.Students)
                   .WithOne(s => s.AcademicBatch)
                   .HasForeignKey(s => s.AcademicBatchId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
