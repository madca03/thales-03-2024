using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentEnrollment.API.Models.Enrollment.RequestModel;
using StudentEnrollment.API.Models.Shared.ResponseModel;
using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;
using StudentEnrollment.Business.Services.Interfaces;

namespace StudentEnrollment.API.Controllers;

[Route("api/enrollment")]
public class EnrollmentController : BaseController
{
    private readonly IEnrollmentService _enrollmentService;
    private readonly IMapper _mapper;
    
    public EnrollmentController(IEnrollmentService enrollmentService,
        IMapper mapper)
    {
        _enrollmentService = enrollmentService;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Gets list of enrollment
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index([FromQuery] GetEnrollmentRequestModel req)
    {
        var data = _enrollmentService.GetEnrollments(_mapper.Map<EnrollmentSearchModel>(req));
        var res = new BaseDataAPIResponseModel { Data = data };
        return GenericSuccess(res);
    }

    /// <summary>
    /// Update enrollment status
    /// </summary>
    /// <returns></returns>
    [HttpPost(":enrollmentId/status/update")]
    public IActionResult UpdateEnrollmentStatus([FromRoute] int enrollmentId, [FromBody] UpdateEnrollmentStatusRequestModel req)
    {
        bool success = _enrollmentService.UpdateEnrollmentStatus(enrollmentId, req.Status);
        var res = new BaseDataAPIResponseModel { Data = success };
        return GenericSuccess(res);
    }

    /// <summary>
    /// Register / Enroll course
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public IActionResult RegisterCourse([FromBody] List<RegisterEnrollmentDTO> req)
    {
        var newEnrollments = _enrollmentService.RegisterEnrollment(req);
        var res = new BaseDataAPIResponseModel { Data = newEnrollments };
        return GenericSuccess(res);
    }
}