using System;
using System.Collections.Generic;
using System.Text;

using EdVerse.Data.Data.Entity.Academic;

namespace EdVerse.Interfaces.Services.Academic
{
    public interface ICourseService
    {
        // Read

        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course?> GetByIdAsync(int id);

        Task<Course?> GetByCourseCodeAsync(string courseCode);

        Task<bool> ExistsAsync(int id);

        Task<bool> CourseCodeExistsAsync(string courseCode);

        // Write

        Task AddAsync(Course course);

        Task UpdateAsync(Course course);

        Task DeleteAsync(int id);
    }
}