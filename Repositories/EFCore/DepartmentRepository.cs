using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class DepartmentRepository : RepositoryBase<Department> , IDepartmentRepository
{
    public DepartmentRepository(RepositoryContext context) : base(context)
    {
    }
    
    public async Task<(List<Department> Departments, MetaData metaData)> GetAllDepartments(DepartmentParameters departmentParameters,
        bool trackChanges)
    {
        var query = FindAll(trackChanges)
            .OrderBy(d => d.Id)
            .Where(d => d.IsActive == true)
            .Search(departmentParameters.SearchTerm)
            .Includes(departmentParameters.Includes)
            .Pagination(departmentParameters.PageNumber, departmentParameters.PageSize);

        MetaData metaData = query.MetaData;
        var departments = await query.Items.ToListAsync();

        return (departments, metaData);
    }

    public async Task<Department> GetDepartmentById(int id, bool trackChanges) =>
        await FindByCondition(d => d.Id.Equals(id), trackChanges)
            .Include(d=>d.Faculty)
            .SingleOrDefaultAsync();
    

    public Department CreateDepartment(Department department) => Create(department);

    public void UpdateDepartment(Department department) => Update(department);

    public void DeleteDepartment(Department department) => Delete(department);
}