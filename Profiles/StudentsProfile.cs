using AutoMapper;
using MyApi.Dtos;
using MyApi.Models;


namespace MyApi.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }

    }

}