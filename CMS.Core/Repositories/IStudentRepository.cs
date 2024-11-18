using CMS.Core.Models;

namespace CMS.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetStudentsAsync();
        Task AddStudentAsync(StudentDto student);
        Task UpdateStudentAsync(StudentDto student);
        Task DeleteStudentAsync(int id);
        Task<StudentDto> GetStudentByIdAsync(int id);
    }
}
