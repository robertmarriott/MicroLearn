using AutoMapper;
using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using CourseCatalog.Domain.Courses.Specifications;
using CourseCatalog.Domain.Instructors;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetCoursesByInstructorId;

public class GetCoursesByInstructorIdQueryHandler(
    ICourseRepository courseRepository,
    IInstructorRepository instructorRepository,
    IMapper mapper)
    : IRequestHandler<GetCoursesByInstructorIdQuery, IReadOnlyList<CourseResponse>>
{
    public async Task<IReadOnlyList<CourseResponse>> Handle(
        GetCoursesByInstructorIdQuery request,
        CancellationToken cancellationToken)
    {
        var instructorExists = await instructorRepository
            .ExistsAsync(request.InstructorId);

        if (!instructorExists)
        {
            throw new InstructorNotFoundException(request.InstructorId);
        }

        var courses = await courseRepository.ListAsync(
            new CoursesByInstructorIdSpecification(request.InstructorId),
            request.PageNumber,
            request.PageSize);

        return mapper.Map<IReadOnlyList<CourseResponse>>(courses);
    }
}
