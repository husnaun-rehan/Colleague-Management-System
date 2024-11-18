using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task AddCourseAsync(CourseDto course)
        {
            await _courseRepository.AddCourseAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteCourseAsync(id);
        }

        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            return await _courseRepository.GetCoursesAsync();
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            return await _courseRepository.GetCourseByIdAsync(id);
        }

        public async Task UpdateCourseAsync(CourseDto course)
        {
            await _courseRepository.UpdateCourseAsync(course);
        }
    }
}
