using AutoMapper;
using CourseCatalog.Application.Instructors.Queries.GetAllInstructors;
using CourseCatalog.Application.Instructors.Queries.GetCoursesByInstructorId;
using CourseCatalog.Application.Instructors.Queries.GetInstructorById;
using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Contracts.Instructors.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseCatalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController(IMediator mediator, IMapper mapper)
    : ControllerBase
{
    private const int DefaultPageNumber = 1;
    private const int DefaultPageSize = 10;

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<InstructorResponse>>> GetAll(
        [FromQuery] int pageNumber = DefaultPageNumber,
        [FromQuery] int pageSize = DefaultPageSize)
    {
        var query = mapper.Map<GetAllInstructorsQuery>((pageNumber, pageSize));

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{instructorId:guid}")]
    public async Task<ActionResult<InstructorResponse>> GetById(
        [FromRoute] Guid instructorId)
    {
        var query = mapper.Map<GetInstructorByIdQuery>(instructorId);

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{instructorId:guid}/courses")]
    public async Task<ActionResult<PaginatedResponse<CourseResponse>>> GetCourses(
        [FromRoute] Guid instructorId,
        [FromQuery] int pageNumber = DefaultPageNumber,
        [FromQuery] int pageSize = DefaultPageSize)
    {
        var query = mapper.Map<GetCoursesByInstructorIdQuery>(
            (instructorId, pageNumber, pageSize));

        var response = await mediator.Send(query);

        return Ok(response);
    }
}
