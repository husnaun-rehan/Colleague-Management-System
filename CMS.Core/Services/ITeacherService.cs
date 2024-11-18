using CMS.Core.Models;


namespace CMS.Core.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetTeachersAsync();

        Task AddTeacherAsync(TeacherDto teacher);

        Task UpdateTeacherAsync(TeacherDto teacher);
        Task DeleteTeacherAsync(TeacherDto teacher);
        Task DeleteTeacherAsync(int deleteId);
        Task<TeacherDto> GetTeacherByIdAsync(int updateId);
    }
}
