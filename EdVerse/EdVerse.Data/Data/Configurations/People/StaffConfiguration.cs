using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdVerse.Data.Data.Configurations.People
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            // Table

            builder.ToTable("Staff");

            // Primary Key

            builder.HasKey(s => s.Id);

            // Properties

            builder.Property(s => s.EmployeeCode)
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
          
            builder.Property(s => s.BloodGroup)
                   .HasMaxLength(10);

            builder.Property(s => s.Qualification)
                   .HasMaxLength(200);

            builder.Property(s => s.Address)
                   .HasMaxLength(500);

            builder.Property(s => s.ProfilePhoto)
                   .HasMaxLength(500);

            builder.Property(s => s.ExperienceInYears)
                   .HasPrecision(4, 1);

            builder.Property(s => s.JoiningDate)
                   .IsRequired();

            builder.Property(s => s.StaffType)
                   .IsRequired();

            // Indexes

            builder.HasIndex(s => s.EmployeeCode)
                   .IsUnique();

            // Relationships

            builder.HasOne(s => s.ApplicationUser)
                   .WithOne()
                   .HasForeignKey<Staff>(s => s.ApplicationUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Department)
                   .WithMany(d => d.StaffMembers)
                   .HasForeignKey(s => s.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.FacultySubjects)
                   .WithOne(fs => fs.Staff)
                   .HasForeignKey(fs => fs.StaffId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
