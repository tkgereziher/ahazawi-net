using Ahazawi.Domain.Progress;
using MediatR;

namespace Ahazawi.Application.Progress.Queries.GetCourseProgress;

public record GetCourseProgressQuery(Guid StudentId, Guid CourseId) : IRequest<StudentProgress?>;
