using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class TeacherRepository : RepositoryBase<Teacher>,ITeacherRepository
{
    public TeacherRepository(RepositoryContext context) : base(context)
    {
    }

    public async Task<(List<Teacher> teachers, MetaData metaData)> GetAllFaculties(TeacherParameters teacherParameters, bool trackChanges)
    {
        var query = FindAll(trackChanges)
            .OrderBy(t => t.Id)
            .Where(t => t.IsActive == true)
            .Search(teacherParameters.SearchTerm)
            .Includes(teacherParameters.Includes)
            .Pagination(teacherParameters.PageNumber, teacherParameters.PageSize);

        MetaData metaData = query.MetaData;
        var teachers = await query.Items.ToListAsync();

        return (teachers, metaData);
    }

    public async Task<Teacher> GetTeacherById(int id, bool trackChanges) =>
        await FindByCondition(t => t.Id.Equals(id), trackChanges)
            .Include(t => t.Faculty)
            .Include(t => t.Rank)
            .SingleOrDefaultAsync();
    
    public Teacher CreateTeacher(Teacher teacher) => Create(teacher);

    public void UpdateTeacher(Teacher teacher) => Update(teacher);

    public void DeleteTeacher(Teacher teacher) => Delete(teacher);
    
}