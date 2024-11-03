using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects.Department;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;

namespace Services.Contracts;

public class DepartmentManager : IDepartmentService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public DepartmentManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<ExpandoObject> shapedData, MetaData metaData)> GetAllDepartments(DepartmentParameters departmentParameters,
        bool trackChanges)
    {
        var departments = await _manager
            .Department
            .GetAllDepartments(departmentParameters, trackChanges);
        
        var departmentsDto = _mapper.Map<List<DepartmentDto>>(departments.Departments);
        
        var shapedData = DataShaper.ShapeData(departmentsDto,departmentParameters.Fields,typeof(DepartmentDto));
        return (shapedData, departments.metaData);
    }

    public async Task<DepartmentDto> GetDepartmentById(int id, bool trackChanges)
    {
        var department = await GetDepartmentAndCheckExists(id, trackChanges);
        var departmentDto = _mapper.Map<DepartmentDto>(department);
        return departmentDto;
    }

    public async Task<DepartmentDto> CreateDepartment(DepartmentDtoForCreate departmentDto)
    {
        var department = _manager.Department.CreateDepartment(_mapper.Map<Department>(departmentDto));
        await _manager.Save();
        
        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task UpdateDepartment(int id, DepartmentDtoForUpdate departmentDto, bool trackChanges)
    {
        var department = await GetDepartmentAndCheckExists(id, trackChanges);
        _mapper.Map(departmentDto, department);
        await _manager.Save();
    }

    public async Task DeleteDepartment(int id, bool trackChanges)
    {
        var department = await GetDepartmentAndCheckExists(id, trackChanges);
        department.IsActive = false;
        await _manager.Save();
    }

    private async Task<Department> GetDepartmentAndCheckExists(int id, bool trackChanges)
    {
        var department = await _manager.Department.GetDepartmentById(id, trackChanges);
        if (department is null)
            throw new NotFoundException("istenen departman bulunamadı.");
        return department;
    }
}