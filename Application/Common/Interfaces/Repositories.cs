using Ahazawi.Domain.Students;
using Ahazawi.Domain.Courses;
using Ahazawi.Domain.Progress;

namespace Ahazawi.Application.Common.Interfaces;

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
