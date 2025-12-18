using MediatR;
using Momona.Domain.Students;

namespace Momona.Application.Progress.Commands.CompleteLesson;

public record CompleteLessonCommand(Guid StudentId, Guid CourseId, Guid LessonId) : IRequest<Unit>;
