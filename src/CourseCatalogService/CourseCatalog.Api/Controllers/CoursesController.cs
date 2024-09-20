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
}
