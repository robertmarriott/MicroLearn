﻿using AutoMapper;
using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using CourseCatalog.Domain.Courses.Specifications;
using MediatR;

namespace CourseCatalog.Application.Courses.Queries.GetAllCourses;

public class GetAllCoursesQueryHandler(
    ICourseRepository courseRepository,
    IMapper mapper)
    : IRequestHandler<GetAllCoursesQuery, PaginatedResponse<CourseResponse>>
{
    public async Task<PaginatedResponse<CourseResponse>> Handle(
        GetAllCoursesQuery request,
        CancellationToken cancellationToken)
    {
        var allCoursesSpecification = new AllCoursesSpecification();

        var courses = await courseRepository.ListAsync(
            allCoursesSpecification,
            request.PageNumber,
            request.PageSize);

        var courseResponses = mapper.Map<IReadOnlyList<CourseResponse>>(
            courses);

        var totalCount = await courseRepository.CountAsync(
            allCoursesSpecification);

        return new PaginatedResponse<CourseResponse>(
            courseResponses,
            request.PageNumber,
            request.PageSize,
            totalCount);
    }
}
