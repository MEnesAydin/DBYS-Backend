using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface IDepartmentRepository : IRepositoryBase<Department>
{
    Task<(List<Department> Departments, MetaData metaData)> GetAllDepartments(DepartmentParameters departmentParameters
        ,bool trackChanges);
    Task<Department> GetDepartmentById(int id, bool trackChanges);
    Department CreateDepartment(Department department);
    void UpdateDepartment(Department department);
    void DeleteDepartment(Department department);
}