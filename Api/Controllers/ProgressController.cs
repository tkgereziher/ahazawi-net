using Momona.Application.Progress.Commands.CompleteLesson;
using Momona.Application.Progress.Queries.GetCourseProgress;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Momona.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgressController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProgressController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CompleteLesson(CompleteLessonCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{studentId}/{courseId}")]
    public async Task<IActionResult> GetProgress(Guid studentId, Guid courseId)
    {
        var progress = await _mediator.Send(new GetCourseProgressQuery(studentId, courseId));
        return Ok(progress);
    }
}
