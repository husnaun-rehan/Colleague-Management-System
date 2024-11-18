using CMS.Core.Models;

namespace CMS.Core.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<DepartmentDto>> GetDepartmentsAsync();
        Task AddDepartmentAsync(DepartmentDto department);
        Task UpdateDepartmentAsync(DepartmentDto department);
        Task DeleteDepartmentAsync(int id);
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);
    }
}
