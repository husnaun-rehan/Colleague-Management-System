using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Core.Repositories;
using CMS.Repositories;

namespace CMS.Services
{
    public class TeacherService : ITeacherService
    {
        public async Task AddTeacherAsync(TeacherDto teacher)
        {
            ITeacherRepository teacherRepository = new TeacherRepository();
            await teacherRepository.AddTeacherAsync(teacher);
        }

        public Task DeleteTeacherAsync(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherDto>> GetTeachersAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherAsync(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }
    }
}
