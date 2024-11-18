using CMS.Core.Interfaces;
using CMS.Core.Models;
using CMS.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task AddDepartmentAsync(DepartmentDto department)
        {
            await _departmentRepository.AddDepartmentAsync(department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);
        }

        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
        {
            return await _departmentRepository.GetDepartmentsAsync();
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(id);
        }

        public async Task UpdateDepartmentAsync(DepartmentDto department)
        {
            await _departmentRepository.UpdateDepartmentAsync(department);
        }
    }
}
