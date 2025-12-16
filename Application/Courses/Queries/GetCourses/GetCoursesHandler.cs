using Ahazawi.Application.Common.Interfaces;
using Ahazawi.Domain.Courses;
using MediatR;

namespace Ahazawi.Application.Courses.Queries.GetCourses;



public class GetCoursesHandler : IRequestHandler<GetCoursesQuery, IEnumerable<Course>>
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return await _courseRepository.GetAllAsync(cancellationToken);
    }
}
