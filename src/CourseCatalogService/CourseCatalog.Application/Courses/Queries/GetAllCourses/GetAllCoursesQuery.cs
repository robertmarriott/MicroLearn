using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Courses.Responses;
using MediatR;

namespace CourseCatalog.Application.Courses.Queries.GetAllCourses;

public record class GetAllCoursesQuery(int PageNumber, int PageSize)
    : IRequest<PaginatedResponse<CourseResponse>>;
