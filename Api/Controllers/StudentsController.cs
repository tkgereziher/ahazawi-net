using Momona.Application.Students.Commands.CreateStudent;
using Momona.Application.Students.Queries.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Momona.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));
        if (student == null)
            return NotFound();

        return Ok(student);
    }
}
