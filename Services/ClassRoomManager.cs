using System.Dynamic;
using AutoMapper;
using Entities.DataTransferObjects.ClassRoom;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;

namespace Services;

public class ClassRoomManager : IClassRoomService
{
    private readonly IRepositoryManager _manager;
    private readonly ILoggerService _logger;
    private readonly IMapper _mapper;

    public ClassRoomManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
    {
        _manager = manager;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<(IEnumerable<ExpandoObject> shapedData, MetaData MetaData)> GetAllClassRooms(ClassRoomParameters classRoomParameters, bool trackChanges)
    {
        var classRooms = await _manager
            .ClassRoom
            .GetAllClassRooms(classRoomParameters, trackChanges);

        var classRoomsDto = _mapper.Map <List<ClassRoomDto>>(classRooms.classRooms);

        var shapedData = DataShaper.ShapeData(classRoomsDto, classRoomParameters.Fields, typeof(ClassRoomDto));
        return (shapedData, classRooms.metaData);
    }

    public async Task<ClassRoomDto> GetClassRoomById(int id, bool trackChanges)
    {
        var classRooms = await GetClassRoomAndCheckExists(id, trackChanges);
        var classRoomDto = _mapper.Map<ClassRoomDto>(classRooms);
        return classRoomDto;
    }

    public async Task<ClassRoomDto> CreateClassRoom(ClassRoomDtoForCreate classRoomDto)
    {
        var classRoom = _manager.ClassRoom.CreateClassRoom(_mapper.Map<ClassRoom>(classRoomDto));
        await _manager.Save();

        return _mapper.Map<ClassRoomDto>(classRoom);
    }

    public async Task UpdateClassRoom(int id, ClassRoomDtoForUpdate classRoomDto, bool trackChanges)
    {
        var classRoom = await GetClassRoomAndCheckExists(id, trackChanges);
        _mapper.Map(classRoomDto, classRoom);
        await _manager.Save();
    }

    public async Task DeleteClassRoom(int id, bool trackChanges)
    {
        var classRoom = await GetClassRoomAndCheckExists(id, trackChanges);
        classRoom.IsActive = false;
        await _manager.Save();
    }
    
    private async Task<ClassRoom> GetClassRoomAndCheckExists(int id, bool trackChanges)
    {
        var classRoom = await _manager.ClassRoom.GetClassRoomById(id, trackChanges);
        if (classRoom is null)
            throw new NotFoundException("istenen derslik bulunamadı.");
        return classRoom;
    }
}