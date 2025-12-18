using Momona.Domain.Students;
using MediatR;

namespace Momona.Application.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(Guid Id) : IRequest<Student?>;
