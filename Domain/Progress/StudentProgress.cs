using Momona.Domain.Abstractions;
using Momona.Domain.Common;
using Momona.Domain.Students;

namespace Momona.Domain.Progress;

public class StudentProgress : BaseEntity<Guid>, IAggregateRoot
{
    public StudentId StudentId { get; private set; }
    public Guid CourseId { get; private set; }
    public Guid LessonId { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    private StudentProgress() { }

    public StudentProgress(Guid id, StudentId studentId, Guid courseId, Guid lessonId)
    {
        Id = id;
        StudentId = studentId;
        CourseId = courseId;
        LessonId = lessonId;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
        CompletedAt = DateTime.UtcNow;
    }
}
