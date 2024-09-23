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

    [HttpGet("{instructorId:guid}")]
    public async Task<IActionResult> GetById(Guid instructorId)
    {
        var query = mapper.Map<GetInstructorByIdQuery>(instructorId);

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{instructorId:guid}/courses")]
    public async Task<IActionResult> GetCourses(Guid instructorId)
    {
        var query = mapper.Map<GetCoursesByInstructorIdQuery>(instructorId);

        var response = await mediator.Send(query);

        return Ok(response);
    }
}
