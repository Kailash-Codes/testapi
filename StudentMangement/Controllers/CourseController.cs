using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StudentMangement.Dtos.Course;
using StudentMangement.Models;
using StudentMangement.Services.Interface;

namespace StudentMangement.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<GetCourseDto>>>> Index()
        {
            try
            {
                var courses = await _courseService.GetCourse();
                return Ok(new ResponseModel<List<GetCourseDto>>(true, "Courses fetched successfully", courses));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<List<GetCourseDto>>(false, "Failed to get courses", null, "Cannot get courses", ex.Message));
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<GetCourseDto>>> Index(CreateCourseDto course)
        {
            try
            {
                var newCourse = await _courseService.CreateCourse(course);
                return Ok(new ResponseModel<GetCourseDto>(true, "New Course added successfully", newCourse));

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel<GetCourseDto>(false, "", null, "Cannot add new course", ex.Message));
            }
        }

    }
}
