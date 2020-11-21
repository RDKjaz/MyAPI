using AutoMapper;
using MyApi.Dtos;
using MyApi.Models;

namespace MyApi.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseReadDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseUpdateDto>();
        }

    }

}