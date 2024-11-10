using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.API.Models.Shared.ResponseModel;
using StudentEnrollment.API.Models.Student.RequestModel;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Services.Interfaces;

namespace StudentEnrollment.API.Controllers;

[Route("api/students")]
public class StudentController : BaseController
{
    private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    
    public StudentController(IStudentService studentService,
        IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Gets list of students.
    /// </summary>
    /// <param name="req">Search parameters.</param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index([FromQuery] GetStudentsRequestModel req)
    {
        var data = _studentService.GetStudents(_mapper.Map<StudentSearchModel>(req));
        var res = new BaseDataAPIResponseModel { Data = data };
        return GenericSuccess(res);
    }
}