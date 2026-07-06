using EdVerse.Interfaces.Services.Academic;
using EdVerse.ViewModels.Academic.Course;
using Microsoft.AspNetCore.Mvc;

namespace EdVerse.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();

            var model = courses.Select(c => new CourseListVm
            {
                Id = c.Id,
                CourseCode = c.CourseCode,
                CourseName = c.CourseName,
                DurationInYears = c.DurationInYears,
                TotalSemesters = c.TotalSemesters
            }).ToList();

            return View(model);
        }
    }
}