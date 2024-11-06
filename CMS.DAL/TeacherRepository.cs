using CMS.Core.Models;
using CMS.Core.Repositories;
using CMS.Repositories.Entities;

namespace CMS.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public Task AddTeacherAsync(TeacherDto teacherDto)
        {
            Teacher teacher = new Teacher()
            {
                Id = teacherDto.Id,
                Name = teacherDto.Name,
            };
           // DbContext.Teachers.Add(teacher);
            throw new NotImplementedException();
        }

        public Task DeleteTeacherAsync(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherDto>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TeacherDto>> GetTeacherAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherAsync(TeacherDto teacher)
        {
            throw new NotImplementedException();
        }
    }
}
