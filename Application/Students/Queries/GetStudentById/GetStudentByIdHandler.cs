using Momona.Application.Common.Interfaces;
using Momona.Domain.Students;
using MediatR;

namespace Momona.Application.Students.Queries.GetStudentById;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student?>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetByIdAsync(new StudentId(request.Id), cancellationToken);
    }
}
