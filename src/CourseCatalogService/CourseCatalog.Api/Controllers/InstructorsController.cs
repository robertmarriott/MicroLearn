namespace CourseCatalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController(IMediator mediator, IMapper mapper)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new GetAllInstructorsQuery());

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = mapper.Map<GetInstructorByIdQuery>(id);

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{id:guid}/courses")]
    public async Task<IActionResult> GetCourses(Guid id)
    {
        var query = mapper.Map<GetCoursesByInstructorIdQuery>(id);

        var response = await mediator.Send(query);

        return Ok(response);
    }
}
