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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly CMSDbContext _context;

        public TeacherRepository(CMSDbContext context)
        {
            _context = context;
        }

        private TeacherDto ToDto(Teacher teacher)
        {
            return new TeacherDto(teacher.Id, teacher.Name, teacher.Description, teacher.Type, teacher.DepartmentId);
        }

        private Teacher ToEntity(TeacherDto teacherDto)
        {
            return new Teacher
            {
                Id = teacherDto.Id,
                Name = teacherDto.Name,
                Description = teacherDto.Description,
                Type = teacherDto.Type,
                DepartmentId = teacherDto.DepartmentId
            };
        }

        public async Task AddTeacherAsync(TeacherDto teacherDto)
        {
            var teacher = ToEntity(teacherDto);
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
            var teachers = await _context.Teachers.Include(t => t.Department).ToListAsync();
            return teachers.Select(ToDto).ToList();
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.Include(t => t.Department).FirstOrDefaultAsync(t => t.Id == id);
            return teacher != null ? ToDto(teacher) : null;
        }

        public async Task UpdateTeacherAsync(TeacherDto teacherDto)
        {
            var existingTeacher = await _context.Teachers.FindAsync(teacherDto.Id);
            if (existingTeacher != null)
            {
                existingTeacher.Name = teacherDto.Name;
                existingTeacher.Description = teacherDto.Description;
                existingTeacher.Type = teacherDto.Type;
                existingTeacher.DepartmentId = teacherDto.DepartmentId;
                _context.Entry(existingTeacher).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
