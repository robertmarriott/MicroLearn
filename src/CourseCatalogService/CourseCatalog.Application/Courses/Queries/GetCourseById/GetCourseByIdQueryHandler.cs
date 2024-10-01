using AutoMapper;
using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQueryHandler(
    ICourseRepository courseRepository,
    IMapper mapper) : IRequestHandler<GetCourseByIdQuery, CourseResponse>
{
    public async Task<CourseResponse> Handle(
        GetCourseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        return mapper.Map<CourseResponse>(course);
    }
}
