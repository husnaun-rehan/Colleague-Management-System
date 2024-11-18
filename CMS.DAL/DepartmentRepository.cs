using CMS.Core.Models;
using CMS.Core.Repositories;
using CMS.Repositories.DataBase;
using CMS.Repositories.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CMSDbContext _context;

        public DepartmentRepository(CMSDbContext context)
        {
            _context = context;
        }

        private DepartmentDto ToDto(Department department)
        {
            return new DepartmentDto(department.Id, department.Name, department.Description);
        }

        private Department ToEntity(DepartmentDto departmentDto)
        {
            return new Department
            {
                Id = departmentDto.Id,
                Name = departmentDto.Name,
                Description = departmentDto.Description
            };
        }

        public async Task AddDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = ToEntity(departmentDto);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DepartmentDto>> GetDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments.Select(ToDto).ToList();
        }

        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department != null ? ToDto(department) : null;
        }

        public async Task UpdateDepartmentAsync(DepartmentDto departmentDto)
        {
            var existingDepartment = await _context.Departments.FindAsync(departmentDto.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = departmentDto.Name;
                existingDepartment.Description = departmentDto.Description;
                _context.Entry(existingDepartment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
