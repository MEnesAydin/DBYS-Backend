using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore;

public class ClassRoomRepository : RepositoryBase<ClassRoom> , IClassRoomRepository
{
    public ClassRoomRepository(RepositoryContext context) : base(context)
    {
            
    }

    public async Task<(List<ClassRoom> classRooms, MetaData metaData)> GetAllClassRooms(ClassRoomParameters classRoomParameters, bool trackChanges)
    {
        var query = FindAll(trackChanges)
            .OrderBy(c => c.Id)
            .Where(c => c.IsActive == true)
            .Search(classRoomParameters.SearchTerm)
            .Includes(classRoomParameters.Includes)
            .Pagination(classRoomParameters.PageNumber, classRoomParameters.PageSize);

        MetaData metaData = query.MetaData;
        var classRooms = await query.Items.ToListAsync();

        return (classRooms, metaData);
    }

    public async Task<ClassRoom> GetClassRoomById(int id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .Include(c => c.Faculty)
            .SingleOrDefaultAsync();

    public ClassRoom CreateClassRoom(ClassRoom classRoom) => Create(classRoom);

    public void UpdateClassRoom(ClassRoom classRoom) => Update(classRoom);

    public void DeleteClassRoom(ClassRoom classRoom) => Delete(classRoom);
}