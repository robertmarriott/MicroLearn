using AutoMapper;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using CourseCatalog.Domain.Courses.Specifications;
using MediatR;

namespace CourseCatalog.Application.Courses.Queries.GetAllCourses;

public class GetAllCoursesQueryHandler(
    ICourseRepository courseRepository,
    IMapper mapper)
    : IRequestHandler<GetAllCoursesQuery, IReadOnlyList<CourseResponse>>
{
    public async Task<IReadOnlyList<CourseResponse>> Handle(
        GetAllCoursesQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await courseRepository.ListAsync(
            new AllCoursesSpecification(),
            request.PageNumber,
            request.PageSize);

        return mapper.Map<IReadOnlyList<CourseResponse>>(courses);
    }
}
