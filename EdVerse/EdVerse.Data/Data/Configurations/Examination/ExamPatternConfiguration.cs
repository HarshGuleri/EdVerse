using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Examination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Examination
{
    public class ExamPatternConfiguration : IEntityTypeConfiguration<ExamPattern>
    {
        public void Configure(EntityTypeBuilder<ExamPattern> builder)
        {
            builder.ToTable("ExamPatterns");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PatternCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.PatternName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.HasIndex(x => x.PatternCode)
                   .IsUnique();

            builder.HasMany(x => x.ExamComponents)
                   .WithOne(c => c.ExamPattern)
                   .HasForeignKey(c => c.ExamPatternId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Subjects)
                   .WithOne(s => s.ExamPattern)
                   .HasForeignKey(s => s.ExamPatternId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.Semesters)
                   .WithOne(s => s.DefaultExamPattern)
                   .HasForeignKey(s => s.DefaultExamPatternId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}