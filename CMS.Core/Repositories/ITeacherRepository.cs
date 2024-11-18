using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.Core.Models;

namespace CMS.Core.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<TeacherDto>> GetTeachersAsync();
        Task AddTeacherAsync(TeacherDto teacher);
        Task UpdateTeacherAsync(TeacherDto teacher);
        Task DeleteTeacherAsync(int id);
        Task<TeacherDto> GetTeacherByIdAsync(int id);
    }
}
