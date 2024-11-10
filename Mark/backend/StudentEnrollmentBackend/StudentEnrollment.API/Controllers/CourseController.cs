using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.API.Models.Course.RequestModel;
using StudentEnrollment.API.Models.Shared.ResponseModel;
using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Services.Interfaces;

namespace StudentEnrollment.API.Controllers;

[Route("api/courses")]
public class CourseController : BaseController
{
    private readonly ICourseService _courseService;
    private readonly IMapper _mapper;
    
    public CourseController(ICourseService courseService,
        IMapper mapper)
    {
        _courseService = courseService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Get Courses
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index([FromQuery] GetCoursesRequestModel req)
    {
        var data = _courseService.GetCourses(_mapper.Map<CourseSearchModel>(req));
        var res = new BaseDataAPIResponseModel { Data = data };
        return GenericSuccess(res);
    }

    /// <summary>
    /// Adds a course
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public IActionResult AddCourse([FromBody] CreateCourseRequestModel req)
    {
        var addedCourse = _courseService.AddCourse(_mapper.Map<CourseDTO>(req));
        var res = new BaseDataAPIResponseModel { Data = addedCourse };
        return GenericSuccess(res);
    }

    /// <summary>
    /// Deletes a course
    /// </summary>
    /// <param name="id">Course id.</param>
    /// <returns></returns>
    [HttpDelete("{id}/delete")]
    public IActionResult DeleteCourse([FromRoute] int id)
    {
        var success = _courseService.DeleteCourse(id);
        var res = new BaseDataAPIResponseModel { Data = success };
        return GenericSuccess(res);
    }

    /// <summary>
    /// Updates a course
    /// </summary>
    /// <returns></returns>
    [HttpPost("{id}/edit")]
    public IActionResult EditCourse([FromBody] EditCourseRequestModel req)
    {
        var updatedCourse = _courseService.EditCourse(_mapper.Map<CourseDTO>(req));
        var res = new BaseDataAPIResponseModel { Data = updatedCourse };
        return GenericSuccess(res);
    }
}