using AutoMapper;
using MyApi.Dtos;
using MyApi.Models;

namespace MyApi.Profiles
{
    public class GradesProfile : Profile
    {
        public GradesProfile()
        {
            CreateMap<Grade, GradeReadDto>();
            CreateMap<GradeCreateDto, Grade>();
            CreateMap<GradeUpdateDto, Grade>();
            CreateMap<Grade, GradeUpdateDto>();
        }

    }

}