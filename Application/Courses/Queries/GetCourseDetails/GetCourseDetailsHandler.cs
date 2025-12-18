using Momona.Application.Common.Interfaces;
using Momona.Domain.Courses;
using MediatR;

namespace Momona.Application.Courses.Queries.GetCourseDetails;



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
