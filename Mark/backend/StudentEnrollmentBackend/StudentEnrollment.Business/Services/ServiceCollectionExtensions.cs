using Microsoft.Extensions.DependencyInjection;
using StudentEnrollment.Business.Services.Interfaces;

namespace StudentEnrollment.Business.Services;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        return services;
    }
}