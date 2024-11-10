using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace StudentEnrollment.Business.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString, ILogger logger)
    {
        /*
        services.AddDbContext<StudentEnrollmentContext>(options =>
            options.UseSqlServer(connectionString)
                .LogTo(logger.Information));
        */

        services.AddDbContext<StudentEnrollmentContext>(options =>
            options.UseSqlServer(connectionString));
        
        return services;
    }
}