using System;
using StudentMangement.Dtos.Course;

namespace StudentMangement.Services.Interface
{
    public interface ICourseService
    {
        Task<List<GetCourseDto>> GetCourse();
        Task<GetCourseDto> CreateCourse(CreateCourseDto createCourseDto);
        Task<GetCourseDto> UpdateCourse(UpdateCourseDto updateCourseDto);
        Task<GetCourseDto> DeleteCourse(int courseId);
        Task<GetCourseDto> GetCourseByCourseId(int courseId);
    }
}
