namespace CourseCatalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(IMediator mediator, IMapper mapper)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllCoursesQuery();

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{courseId:guid}")]
    public async Task<IActionResult> GetById(Guid courseId)
    {
        var query = mapper.Map<GetCourseByIdQuery>(courseId);

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseRequest request)
    {
        // TODO: Include InstructorId
        var command = mapper.Map<CreateCourseCommand>(request);

        var response = await mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPost("{courseId:guid}/title")]
    public async Task<IActionResult> ChangeTitle(
        Guid courseId,
        ChangeCourseTitleRequest request)
    {
        // TODO: Ensure only the owner of the course can modify it
        var command = mapper.Map<ChangeCourseTitleCommand>((courseId, request));

        await mediator.Send(command);

        return NoContent();
    }
}
