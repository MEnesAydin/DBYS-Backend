using System.Dynamic;
using Entities.DataTransferObjects.Department;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IDepartmentService
{
    Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllDepartments(DepartmentParameters departmentParameters,
    bool trackChanges);
    Task<DepartmentDto> GetDepartmentById(int id,bool trackChanges);
    Task<DepartmentDto> CreateDepartment(DepartmentDtoForCreate departmentDto);
    Task UpdateDepartment(int id, DepartmentDtoForUpdate departmentDto, bool trackChanges);
    Task DeleteDepartment(int id, bool trackChanges);
}