using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.Academic
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table

            builder.ToTable("Departments");

            // Primary Key

            builder.HasKey(d => d.Id);

            // Properties

            builder.Property(d => d.DepartmentCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(d => d.DepartmentName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(d => d.Description)
                   .HasMaxLength(500);

            // Unique Index

            builder.HasIndex(d => d.DepartmentCode)
                   .IsUnique();

            // Relationships

            builder.HasOne(d => d.Course)
                   .WithMany(c => c.Departments)
                   .HasForeignKey(d => d.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.Students)
                   .WithOne(s => s.Department)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(d => d.StaffMembers)
                   .WithOne(s => s.Department)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}