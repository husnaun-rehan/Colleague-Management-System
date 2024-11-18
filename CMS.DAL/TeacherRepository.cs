using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Models;
using CMS.Core.Repositories;
using CMS.Repositories.DataBase;
using CMS.Repositories.Entities;

namespace CMS.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly CMSDbContext _context;

        public TeacherRepository()
        {
            _context = new CMSDbContext();
        }

        private TeacherDto ToDto(Teacher teacher)
        {
            return new TeacherDto(teacher.Id, teacher.Name, teacher.Description, teacher.Type);
        }

        private Teacher ToEntity(TeacherDto teacherDto)
        {
            return new Teacher
            {
                Id = teacherDto.Id,
                Name = teacherDto.Name,
                Description = teacherDto.Description,
                Type = teacherDto.Type
            };
        }

        public async Task AddTeacherAsync(TeacherDto teacherDto)
        {
            var teacher = new Teacher
            {
                Name = teacherDto.Name,
                Description = teacherDto.Description,
                Type = teacherDto.Type
            };
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TeacherDto>> GetTeachersAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return teachers.Select(t => ToDto(t)).ToList();
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            return teacher != null ? ToDto(teacher) : null;
        }

        public async Task UpdateTeacherAsync(TeacherDto teacherDto)
        {
            var existingTeacher = await _context.Teachers.FindAsync(teacherDto.Id);
            if (existingTeacher != null)
            {
                // Update the properties of the existing entity
                existingTeacher.Name = teacherDto.Name;
                existingTeacher.Description = teacherDto.Description;
                existingTeacher.Type = teacherDto.Type;

                // Mark the entity as modified
                _context.Entry(existingTeacher).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
        }
    }
}
