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
    public class StudentRepository : IStudentRepository
    {
        private readonly CMSDbContext _context;

        public StudentRepository(CMSDbContext context)
        {
            _context = context;
        }

        private StudentDto ToDto(Student student)
        {
            return new StudentDto(student.Id, student.Name, student.EnrollmentNumber, student.DepartmentId, student.Courses.Select(c => c.Id).ToList());
        }

        private Student ToEntity(StudentDto studentDto)
        {
            var student = new Student
            {
                Id = studentDto.Id,
                Name = studentDto.Name,
                EnrollmentNumber = studentDto.EnrollmentNumber,
                DepartmentId = studentDto.DepartmentId,
                Courses = _context.Courses.Where(c => studentDto.CourseIds.Contains(c.Id)).ToList()
            };
            return student;
        }

        public async Task AddStudentAsync(StudentDto studentDto)
        {
            var student = ToEntity(studentDto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            var students = await _context.Students.Include(s => s.Courses).ToListAsync();
            return students.Select(ToDto).ToList();
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
            return student != null ? ToDto(student) : null;
        }

        public async Task UpdateStudentAsync(StudentDto studentDto)
        {
            var existingStudent = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == studentDto.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = studentDto.Name;
                existingStudent.EnrollmentNumber = studentDto.EnrollmentNumber;
                existingStudent.DepartmentId = studentDto.DepartmentId;
                existingStudent.Courses = _context.Courses.Where(c => studentDto.CourseIds.Contains(c.Id)).ToList();
                _context.Entry(existingStudent).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
