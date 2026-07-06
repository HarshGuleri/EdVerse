using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace EdVerse.ViewModels.Academic.Course
{
    public class CourseEditVm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        [StringLength(20)]
        public string CourseCode { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Course Name")]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;

        [Required]
        [Range(1, 10)]
        [Display(Name = "Duration (Years)")]
        public int DurationInYears { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Total Semesters")]
        public int TotalSemesters { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
