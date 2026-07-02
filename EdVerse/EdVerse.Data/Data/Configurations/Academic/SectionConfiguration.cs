using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Academic
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SectionName)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(s => s.Capacity)
                   .IsRequired();

            builder.HasOne(s => s.Semester)
                   .WithMany(se => se.Sections)
                   .HasForeignKey(s => s.SemesterId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.StudentEnrollments)
                   .WithOne(se => se.Section)
                   .HasForeignKey(se => se.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.FacultySubjects)
                   .WithOne(fs => fs.Section)
                   .HasForeignKey(fs => fs.SectionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
