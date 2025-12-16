using Ahazawi.Domain.Courses;
using MediatR;

namespace Ahazawi.Application.Courses.Queries.GetCourses;

public record GetCoursesQuery : IRequest<IEnumerable<Course>>;
