using AutoMapper;
using StudentEnrollment.API.Models.Course.RequestModel;
using StudentEnrollment.API.Models.Enrollment.RequestModel;
using StudentEnrollment.API.Models.Student.RequestModel;
using StudentEnrollment.Business.Models.DTO;
using StudentEnrollment.Business.Models.SearchModels;

namespace StudentEnrollment.API.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetCoursesRequestModel, CourseSearchModel>().ReverseMap();
        CreateMap<CreateCourseRequestModel, CourseDTO>().ReverseMap();
        CreateMap<EditCourseRequestModel, CourseDTO>().ReverseMap();
        CreateMap<GetStudentsRequestModel, StudentSearchModel>().ReverseMap();
        CreateMap<GetEnrollmentRequestModel, EnrollmentSearchModel>().ReverseMap();
    }
}