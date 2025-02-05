using System;
using AutoMapper;
using StudentMangement.Dtos.Course;
using StudentMangement.Models;
using StudentMangement.Repository.Interface;
using StudentMangement.Services.Interface;

namespace StudentMangement.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<CourseModel> _courseRepository;
        public CourseService(IUnitOfWork uow, IRepository<CourseModel> courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<GetCourseDto> CreateCourse(CreateCourseDto createCourseDto)
        {
            try
            {
                var course = _mapper.Map<CourseModel>(createCourseDto);
                await _uow.Repository<CourseModel>().AddAsync(course);
                await _uow.SaveChangesAsync();
                return _mapper.Map<GetCourseDto>(course);
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public Task<GetCourseDto> DeleteCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetCourseDto>> GetCourse()
        {
            try
            {
                var course = await _uow.Repository<CourseModel>().GetAllAsync();
                return _mapper.Map<List<GetCourseDto>>(course);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<GetCourseDto> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            throw new NotImplementedException();
        }
    }
}
