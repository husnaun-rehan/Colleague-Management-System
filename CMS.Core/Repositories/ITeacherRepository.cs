using CMS.Core.Models;

namespace CMS.Core.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<TeacherDto>> GetStudentsAsync();

        Task AddTeacherAsync(TeacherDto teacher);

        Task UpdateTeacherAsync(TeacherDto teacher);
        Task DeleteTeacherAsync(TeacherDto teacher);
    }
}
