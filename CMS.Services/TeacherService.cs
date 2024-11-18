using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task AddTeacherAsync(TeacherDto teacher)
        {
            await _teacherRepository.AddTeacherAsync(teacher);
        }

        public async Task DeleteTeacherAsync(int id)
        {
            await _teacherRepository.DeleteTeacherAsync(id);
        }

        public async Task<List<TeacherDto>> GetTeachersAsync()
        {
            return await _teacherRepository.GetTeachersAsync();
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetTeacherByIdAsync(id);
        }

        public async Task UpdateTeacherAsync(TeacherDto teacher)
        {
            await _teacherRepository.UpdateTeacherAsync(teacher);
        }

        public Task DeleteTeacherAsync(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }
    }
}
