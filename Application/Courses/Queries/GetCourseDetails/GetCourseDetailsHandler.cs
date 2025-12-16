using Ahazawi.Application.Common.Interfaces;
using Ahazawi.Domain.Courses;
using MediatR;

namespace Ahazawi.Application.Courses.Queries.GetCourseDetails;



public class GetCourseDetailsHandler : IRequestHandler<GetCourseDetailsQuery, Course?>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseDetailsHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Course?> Handle(GetCourseDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _courseRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}
