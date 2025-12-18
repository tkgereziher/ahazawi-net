using Momona.Application.Common.Interfaces;
using Momona.Domain.Progress;
using Momona.Domain.Students;
using MediatR;

namespace Momona.Application.Progress.Queries.GetCourseProgress;

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
