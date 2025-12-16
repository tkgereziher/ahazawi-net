using Ahazawi.Application.Common.Interfaces;
using Ahazawi.Domain.Courses;
using Ahazawi.Domain.Progress;
using Ahazawi.Domain.Students;
using Microsoft.EntityFrameworkCore;
using Ahazawi.Infrastructure.Persistence;

namespace Ahazawi.Infrastructure.Persistence.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Student student, CancellationToken cancellationToken)
    {
        await _context.Students.AddAsync(student, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Student?> GetByIdAsync(StudentId id, CancellationToken cancellationToken)
    {
        return await _context.Students.FindAsync(new object[] { id }, cancellationToken);
    }
}

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Courses.ToListAsync(cancellationToken);
    }

    public async Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Courses
            .Include(c => c.Modules)
            .ThenInclude(m => m.Lessons)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}

public class StudentProgressRepository : IStudentProgressRepository
{
    private readonly AppDbContext _context;

    public StudentProgressRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(StudentProgress progress, CancellationToken cancellationToken)
    {
        await _context.StudentProgresses.AddAsync(progress, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<StudentProgress?> GetByStudentAndCourseAsync(StudentId studentId, Guid courseId, CancellationToken cancellationToken)
    {
        return await _context.StudentProgresses
            .FirstOrDefaultAsync(p => p.StudentId == studentId && p.CourseId == courseId, cancellationToken);
    }
}
