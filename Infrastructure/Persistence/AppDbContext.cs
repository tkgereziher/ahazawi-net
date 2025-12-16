// using System.Reflection; (Removed)
using Ahazawi.Domain.Courses;
using Ahazawi.Domain.Progress;
using Ahazawi.Domain.Students;
using Microsoft.EntityFrameworkCore;

namespace Ahazawi.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Module> Modules => Set<Module>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<StudentProgress> StudentProgresses => Set<StudentProgress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
