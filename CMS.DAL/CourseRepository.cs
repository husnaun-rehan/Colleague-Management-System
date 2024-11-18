using CMS.Core.Models;
using CMS.Core.Repositories;
using CMS.Repositories.DataBase;
using CMS.Repositories.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CMSDbContext _context;

        public CourseRepository(CMSDbContext context)
        {
            _context = context;
        }

        private CourseDto ToDto(Course course)
        {
            return new CourseDto(course.Id, course.Name, course.Description, course.DepartmentId, course.Students.Select(s => s.Id).ToList());
        }

        private Course ToEntity(CourseDto courseDto)
        {
            var course = new Course
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Description = courseDto.Description,
                DepartmentId = courseDto.DepartmentId,
                Students = _context.Students.Where(s => courseDto.StudentIds.Contains(s.Id)).ToList()
            };
            return course;
        }

        public async Task AddCourseAsync(CourseDto courseDto)
        {
            var course = ToEntity(courseDto);
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CourseDto>> GetCoursesAsync()
        {
            var courses = await _context.Courses.Include(c => c.Students).ToListAsync();
            return courses.Select(ToDto).ToList();
        }

        public async Task<CourseDto> GetCourseByIdAsync(int id)
        {
            var course = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == id);
            return course != null ? ToDto(course) : null;
        }

        public async Task UpdateCourseAsync(CourseDto courseDto)
        {
            var existingCourse = await _context.Courses.Include(c => c.Students).FirstOrDefaultAsync(c => c.Id == courseDto.Id);
            if (existingCourse != null)
            {
                existingCourse.Name = courseDto.Name;
                existingCourse.Description = courseDto.Description;
                existingCourse.DepartmentId = courseDto.DepartmentId;
                existingCourse.Students = _context.Students.Where(s => courseDto.StudentIds.Contains(s.Id)).ToList();
                _context.Entry(existingCourse).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
