using MediatR;
using Ahazawi.Domain.Students;

namespace Ahazawi.Application.Progress.Commands.CompleteLesson;

public record CompleteLessonCommand(Guid StudentId, Guid CourseId, Guid LessonId) : IRequest<Unit>;
