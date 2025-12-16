using Ahazawi.Application.Courses.Queries.GetCourseDetails;
using Ahazawi.Application.Courses.Queries.GetCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ahazawi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _mediator.Send(new GetCoursesQuery());
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var course = await _mediator.Send(new GetCourseDetailsQuery(id));
        if (course == null)
            return NotFound();

        return Ok(course);
    }
}
