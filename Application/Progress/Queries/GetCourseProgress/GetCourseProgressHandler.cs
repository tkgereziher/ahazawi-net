using Ahazawi.Application.Common.Interfaces;
using Ahazawi.Domain.Progress;
using Ahazawi.Domain.Students;
using MediatR;

namespace Ahazawi.Application.Progress.Queries.GetCourseProgress;

public class GetCourseProgressHandler : IRequestHandler<GetCourseProgressQuery, StudentProgress?>
{
    private readonly IStudentProgressRepository _repository;

    public GetCourseProgressHandler(IStudentProgressRepository repository)
    {
        _repository = repository;
    }

    public async Task<StudentProgress?> Handle(GetCourseProgressQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByStudentAndCourseAsync(new StudentId(request.StudentId), request.CourseId, cancellationToken);
    }
}
