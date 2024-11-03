using Entities.Models;
using Entities.RequestFeatures;

namespace Repositories.Contracts;

public interface IClassRoomRepository : IRepositoryBase<ClassRoom>
{
    Task<(List<ClassRoom> classRooms, MetaData metaData)> GetAllClassRooms(ClassRoomParameters classRoomParameters
        ,bool trackChanges);
    Task<ClassRoom> GetClassRoomById(int id, bool trackChanges);
    ClassRoom CreateClassRoom(ClassRoom classRoom);
    void UpdateClassRoom(ClassRoom classRoom);
    void DeleteClassRoom(ClassRoom classRoom);
}