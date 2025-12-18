using Momona.Domain.Courses;
using MediatR;

namespace Momona.Application.Courses.Queries.GetCourseDetails;

public record GetCourseDetailsQuery(Guid Id) : IRequest<Course?>;
