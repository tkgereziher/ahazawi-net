using Ahazawi.Domain.Courses;
using MediatR;

namespace Ahazawi.Application.Courses.Queries.GetCourseDetails;

public record GetCourseDetailsQuery(Guid Id) : IRequest<Course?>;
