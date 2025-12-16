using Ahazawi.Application.Common.Interfaces;
using Ahazawi.Infrastructure.Files;
using Ahazawi.Infrastructure.Identity;
using Ahazawi.Infrastructure.Persistence;
using Ahazawi.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ahazawi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IStudentProgressRepository, StudentProgressRepository>();
        
        services.AddTransient<FileStorageService>(); // If interface exists, bind it here
        
        services.AddScoped<ICurrentUser, CurrentUserService>();
        services.AddTransient<IDateTime, DateTimeService>(); // Need implementation

        return services;
    }
}

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}
