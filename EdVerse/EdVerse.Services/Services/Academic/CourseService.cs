using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;

using EdVerse.Interfaces.Services.Academic;
using EdVerse.Interfaces.UnitOfWork;

namespace EdVerse.Services.Services.Academic
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ============================
        // Get All Courses
        // ============================

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _unitOfWork.Courses.GetAllAsync();
        }

        // ============================
        // Get Course By Id
        // ============================

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Courses.GetByIdAsync(id);
        }

        // ============================
        // Check Exists
        // ============================

        public async Task<bool> ExistsAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);

            return course != null;
        }

        // ============================
        // Add Course
        // ============================

        public async Task AddAsync(Course course)
        {
            if (await CourseCodeExistsAsync(course.CourseCode))
                throw new Exception("Course Code already exists.");

            await _unitOfWork.Courses.AddAsync(course);

            await _unitOfWork.SaveChangesAsync();
        }

        // ============================
        // Update Course
        // ============================

        public async Task UpdateAsync(Course course)
        {
            var existingCourse = await _unitOfWork.Courses.GetByIdAsync(course.Id);

            if (existingCourse == null)
                throw new Exception("Course not found.");

            var duplicateCourse = (await _unitOfWork.Courses.FindAsync
            (
                c => c.CourseCode == course.CourseCode &&
                     c.Id != course.Id
            )).Any();

            if (duplicateCourse)
                throw new Exception("Course Code already exists.");

            _unitOfWork.Courses.Update(course);

            await _unitOfWork.SaveChangesAsync();
        }

        // ============================
        // Delete Course
        // ============================

        public async Task DeleteAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);

            if (course == null)
                throw new Exception("Course not found.");

            _unitOfWork.Courses.Remove(course);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Course?> GetByCourseCodeAsync(string courseCode)
        {
            return (await _unitOfWork.Courses.FindAsync
            (
                c => c.CourseCode == courseCode
            )).FirstOrDefault();
        }

        public async Task<bool> CourseCodeExistsAsync(string courseCode)
        {
            return (await _unitOfWork.Courses.FindAsync
            (
                c => c.CourseCode == courseCode
            )).Any();
        }
    }
}
