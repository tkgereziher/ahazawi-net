using Ahazawi.Domain.Students;
using MediatR;

namespace Ahazawi.Application.Students.Queries.GetStudentById;

public record GetStudentByIdQuery(Guid Id) : IRequest<Student?>;
