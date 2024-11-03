using AutoMapper;
using DerslikBilgiSistemi.Entity;
using Entities.DataTransferObjects.ClassRoom;
using Entities.DataTransferObjects.Course;
using Entities.DataTransferObjects.CoursePosition;
using Entities.DataTransferObjects.CourseProgram;
using Entities.DataTransferObjects.Department;
using Entities.DataTransferObjects.Faculty;
using Entities.DataTransferObjects.Identity;
using Entities.DataTransferObjects.Rank;
using Entities.DataTransferObjects.Semester;
using Entities.DataTransferObjects.Teacher;
using Entities.Models;

namespace WebApi.Utilities.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClassRoom, ClassRoomDto>().ReverseMap();
        CreateMap<ClassRoomDtoForCreate, ClassRoom>();
        CreateMap<ClassRoomDtoForUpdate, ClassRoom>();

        CreateMap<Course, CourseDto>().ReverseMap();
        CreateMap<CourseDtoForCreate, Course>();
        CreateMap<CourseDtoForUpdate, Course>();

        CreateMap<CoursePosition, CoursePositionDtoForCreate>().ReverseMap();
        CreateMap<CoursePosition, CoursePositionDto>()
            .ForMember(dest => dest.DepartmentId,
                opt => opt.MapFrom(src => src.Course.DepartmentId));
        CreateMap<CoursePosition, CoursePositionWithDetailsDto>();
        
        CreateMap<CourseProgramDtoForCreate, CourseProgram>().ReverseMap();
        CreateMap<CourseProgram, CourseProgramDto>();
        
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<DepartmentDtoForUpdate, Department>();
        CreateMap<DepartmentDtoForCreate, Department>();
        
        CreateMap<Faculty, FacultyDto>().ReverseMap();
        CreateMap<FacultyDtoForCreate, Faculty>();
        CreateMap<FacultyDtoForUpdate, Faculty>();

        CreateMap<Rank, RankDto>().ReverseMap();
        CreateMap<RankDtoForCreate, Rank>();
        CreateMap<RankDtoForUpdate, Rank>();

        CreateMap<SemesterDtoForCreate, Semester>();
        CreateMap<Semester, SemesterDto>();
        
        CreateMap<Teacher, TeacherDto>().ReverseMap();
        CreateMap<TeacherDtoForCreate, Teacher>();
        CreateMap<TeacherDtoForUpdate, Teacher>();
    }
}