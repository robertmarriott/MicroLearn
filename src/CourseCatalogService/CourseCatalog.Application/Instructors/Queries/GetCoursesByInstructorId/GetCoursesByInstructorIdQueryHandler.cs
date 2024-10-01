using AutoMapper;
using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Contracts.Common.Responses;
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
    : IRequestHandler<GetCoursesByInstructorIdQuery, PaginatedResponse<CourseResponse>>
{
    public async Task<PaginatedResponse<CourseResponse>> Handle(
        GetCoursesByInstructorIdQuery request,
        CancellationToken cancellationToken)
    {
        var instructorExists = await instructorRepository
            .ExistsAsync(request.InstructorId);

        if (!instructorExists)
        {
            throw new InstructorNotFoundException(request.InstructorId);
        }

        var coursesByInstructorIdSpecification =
            new CoursesByInstructorIdSpecification(request.InstructorId);

        var courses = await courseRepository.ListAsync(
            coursesByInstructorIdSpecification,
            request.PageNumber,
            request.PageSize);

        var courseResponses = mapper.Map<IReadOnlyList<CourseResponse>>(
            courses);

        var totalCount = await courseRepository.CountAsync(
            coursesByInstructorIdSpecification);

        return new PaginatedResponse<CourseResponse>(
            courseResponses,
            request.PageNumber,
            request.PageSize,
            totalCount);
    }
}
