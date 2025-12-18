using Momona.Domain.Courses;
using MediatR;

namespace Momona.Application.Courses.Queries.GetCourses;

public record GetCoursesQuery : IRequest<IEnumerable<Course>>;
