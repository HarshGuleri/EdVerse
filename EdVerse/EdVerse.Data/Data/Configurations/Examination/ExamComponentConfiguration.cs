using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Examination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Examination
{
    public class ExamComponentConfiguration : IEntityTypeConfiguration<ExamComponent>
    {
        public void Configure(EntityTypeBuilder<ExamComponent> builder)
        {
            builder.ToTable("ExamComponents");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ComponentCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.ComponentName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Weightage)
                   .HasPrecision(5, 2);

            builder.Property(x => x.MaximumMarks)
                   .IsRequired();

            builder.Property(x => x.PassingMarks)
                   .IsRequired();

            builder.Property(x => x.DisplayOrder)
                   .IsRequired();

            builder.HasIndex(x => new
            {
                x.ExamPatternId,
                x.ComponentCode
            }).IsUnique();

            builder.HasOne(x => x.ExamPattern)
                   .WithMany(x => x.ExamComponents)
                   .HasForeignKey(x => x.ExamPatternId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.StudentMarks)
                   .WithOne(sm => sm.ExamComponent)
                   .HasForeignKey(sm => sm.ExamComponentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
