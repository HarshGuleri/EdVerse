using System;
using System.Collections.Generic;
using System.Text;

namespace EdVerse.ViewModels.Academic.Course
{
    public class CourseDetailsVm
    {
        public int Id { get; set; }

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public int DurationInYears { get; set; }

        public int TotalSemesters { get; set; }

        public string? Description { get; set; }
    }
}
