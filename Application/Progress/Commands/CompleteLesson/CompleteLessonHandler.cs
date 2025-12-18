using Momona.Application.Common.Interfaces;
using Momona.Domain.Progress;
using Momona.Domain.Students;
using MediatR;

namespace Momona.Application.Progress.Commands.CompleteLesson;

public class CompleteLessonHandler : IRequestHandler<CompleteLessonCommand, Unit>
{
    private readonly IStudentProgressRepository _repository;

    public CompleteLessonHandler(IStudentProgressRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CompleteLessonCommand request, CancellationToken cancellationToken)
    {
        // Check if already exists?
        var existing = await _repository.GetByStudentAndCourseAsync(new StudentId(request.StudentId), request.CourseId, cancellationToken);
        // Simplified logic: assume new progress entry for exact lesson or updating existing for course?
        // Domain StudentProgress has specific LessonId. 
        // So we likely creating a new StudentProgress entry for this lesson.
        
        var progress = new StudentProgress(Guid.NewGuid(), new StudentId(request.StudentId), request.CourseId, request.LessonId);
        progress.MarkAsCompleted();

        await _repository.AddAsync(progress, cancellationToken);

        return Unit.Value;
    }
}
