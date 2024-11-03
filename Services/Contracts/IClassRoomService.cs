using System.Dynamic;
using Entities.DataTransferObjects.ClassRoom;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts;

public interface IClassRoomService
{
    Task<(IEnumerable<ExpandoObject> shapedData, MetaData MetaData)> GetAllClassRooms(ClassRoomParameters classRoomParameters,
        bool trackChanges);
    Task<ClassRoomDto> GetClassRoomById(int id,bool trackChanges);
    Task<ClassRoomDto> CreateClassRoom(ClassRoomDtoForCreate classRoomDto);
    Task UpdateClassRoom(int id, ClassRoomDtoForUpdate classRoomDto, bool trackChanges);
    Task DeleteClassRoom(int id, bool trackChanges);
}