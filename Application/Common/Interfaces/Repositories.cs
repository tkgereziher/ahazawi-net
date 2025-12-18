using Momona.Domain.Students;
using Momona.Domain.Courses;
using Momona.Domain.Progress;

namespace Momona.Application.Common.Interfaces;

public interface IStudentRepository
{
    Task AddAsync(Student student, CancellationToken cancellationToken);
    Task<Student?> GetByIdAsync(StudentId id, CancellationToken cancellationToken);
}

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync(CancellationToken cancellationToken);
    Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

public interface IStudentProgressRepository
{
    Task AddAsync(StudentProgress progress, CancellationToken cancellationToken);
    Task<StudentProgress?> GetByStudentAndCourseAsync(StudentId studentId, Guid courseId, CancellationToken cancellationToken);
}
