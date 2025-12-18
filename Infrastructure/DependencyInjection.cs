using Momona.Application.Common.Interfaces;
using Momona.Infrastructure.Files;
using Momona.Infrastructure.Identity;
using Momona.Infrastructure.Persistence;
using Momona.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Momona.Infrastructure;

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
