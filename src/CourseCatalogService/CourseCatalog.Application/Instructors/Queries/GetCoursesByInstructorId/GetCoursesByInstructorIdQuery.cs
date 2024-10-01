using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Instructors.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetCoursesByInstructorId;

public record class GetCoursesByInstructorIdQuery(
    InstructorId InstructorId,
    int PageNumber,
    int PageSize)
    : IRequest<PaginatedResponse<CourseResponse>>;
