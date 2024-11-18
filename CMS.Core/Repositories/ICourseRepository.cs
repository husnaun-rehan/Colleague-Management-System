using CMS.Core.Models;

namespace CMS.Core.Repositories
{
    public interface ICourseRepository
    {
        Task<List<CourseDto>> GetCoursesAsync();
        Task AddCourseAsync(CourseDto course);
        Task UpdateCourseAsync(CourseDto course);
        Task DeleteCourseAsync(int id);
        Task<CourseDto> GetCourseByIdAsync(int id);
    }
}
