using AutoMapper;
using CourseCatalog.Application.Courses.Commands.CancelCourse;
using CourseCatalog.Application.Courses.Commands.ChangeCourseEndDate;
using CourseCatalog.Application.Courses.Commands.ChangeCoursePrice;
using CourseCatalog.Application.Courses.Commands.ChangeCourseStartDate;
using CourseCatalog.Application.Courses.Commands.CreateCourse;
using CourseCatalog.Application.Courses.Queries.GetAllCourses;
using CourseCatalog.Application.Courses.Queries.GetCourseById;
using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Courses.Requests;
using CourseCatalog.Contracts.Courses.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CourseCatalog.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(IMediator mediator, IMapper mapper)
    : ControllerBase
{
    private const int DefaultPageNumber = 1;
    private const int DefaultPageSize = 10;

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<CourseResponse>>> GetAll(
        [FromQuery] int pageNumber = DefaultPageNumber,
        [FromQuery] int pageSize = DefaultPageSize)
    {
        var query = mapper.Map<GetAllCoursesQuery>((pageNumber, pageSize));

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("{courseId:guid}")]
    public async Task<ActionResult<CourseResponse>> GetById(
        [FromRoute] Guid courseId)
    {
        var query = mapper.Map<GetCourseByIdQuery>(courseId);

        var response = await mediator.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CourseResponse>> Create(
        [FromBody] CreateCourseRequest request)
    {
        // TODO: Include InstructorId
        var command = mapper.Map<CreateCourseCommand>(request);

        var response = await mediator.Send(command);

        return CreatedAtAction(
            nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPost("{courseId:guid}/startdate")]
    public async Task<ActionResult> ChangeStartDate(
        [FromRoute] Guid courseId,
        [FromBody] ChangeCourseStartDateRequest request)
    {
        // TODO: Ensure only the owner of the course can modify it
        var command = mapper.Map<ChangeCourseStartDateCommand>(
            (courseId, request));

        await mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{courseId:guid}/enddate")]
    public async Task<ActionResult> ChangeEndDate(
        [FromRoute] Guid courseId,
        [FromBody] ChangeCourseEndDateRequest request)
    {
        // TODO: Ensure only the owner of the course can modify it
        var command = mapper.Map<ChangeCourseEndDateCommand>(
            (courseId, request));

        await mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{courseId:guid}/price")]
    public async Task<ActionResult> ChangePrice(
        [FromRoute] Guid courseId,
        [FromBody] ChangeCoursePriceRequest request)
    {
        // TODO: Ensure only the owner of the course can modify it
        var command = mapper.Map<ChangeCoursePriceCommand>(
            (courseId, request));

        await mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{courseId:guid}/cancel")]
    public async Task<ActionResult> Cancel([FromRoute] Guid courseId)
    {
        // TODO: Ensure only the owner of the course can modify it
        var command = mapper.Map<CancelCourseCommand>(courseId);

        await mediator.Send(command);

        return NoContent();
    }
}
