using Momona.Domain.Progress;
using MediatR;

namespace Momona.Application.Progress.Queries.GetCourseProgress;

public record GetCourseProgressQuery(Guid StudentId, Guid CourseId) : IRequest<StudentProgress?>;
