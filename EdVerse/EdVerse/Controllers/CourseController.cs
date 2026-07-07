using EdVerse.Data.Data.Entity.Academic;
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

        // CREATE ACTION
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var course = new Course
                {
                    CourseCode = model.CourseCode,
                    CourseName = model.CourseName,
                    DurationInYears = model.DurationInYears,
                    TotalSemesters = model.TotalSemesters,
                    Description = model.Description
                };

                await _courseService.AddAsync(course);

                TempData["Success"] = "Course created successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }


        // EDIT

        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            var model = new CourseEditVm
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                DurationInYears = course.DurationInYears,
                TotalSemesters = course.TotalSemesters,
                Description = course.Description
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CourseEditVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var course = await _courseService.GetByIdAsync(model.Id);

                if (course == null)
                    return NotFound();

                course.CourseCode = model.CourseCode;
                course.CourseName = model.CourseName;
                course.DurationInYears = model.DurationInYears;
                course.TotalSemesters = model.TotalSemesters;
                course.Description = model.Description;



                await _courseService.UpdateAsync(course);

                TempData["Success"] = "Course updated successfully.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View(model);
            }
        }

        // DETAILS

        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            if (course == null)
                return NotFound();

            var model = new CourseDetailsVm
            {
                Id = course.Id,
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                DurationInYears = course.DurationInYears,
                TotalSemesters = course.TotalSemesters,
                Description = course.Description
            };

            return View(model);
        }

        // DELETE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteAsync(id);

            TempData["Success"] = "Course deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}