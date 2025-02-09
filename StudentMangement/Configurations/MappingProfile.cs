using System;
using AutoMapper;
using StudentMangement.Dtos.Course;
using StudentMangement.Models;

namespace StudentMangement.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseModel, GetCourseDto>().ReverseMap();
            CreateMap<CourseModel, CreateCourseDto>().ReverseMap();
            CreateMap<CourseModel, UpdateCourseDto>().ReverseMap();
            CreateMap<GetCourseDto, UpdateCourseDto>().ReverseMap();
        }
    }
}
