using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task AddStudentAsync(StudentDto student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }

        public async Task<List<StudentDto>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task UpdateStudentAsync(StudentDto student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }
    }
}
