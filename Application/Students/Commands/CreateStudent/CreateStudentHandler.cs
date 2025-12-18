using Momona.Application.Common.Interfaces;
using Momona.Domain.Students;
using MediatR;

namespace Momona.Application.Students.Commands.CreateStudent;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly IStudentRepository _studentRepository;

    public CreateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = Student.Create(request.FirstName, request.LastName, request.Email);
        
        await _studentRepository.AddAsync(student, cancellationToken);

        return student.Id.Value;
    }
}
