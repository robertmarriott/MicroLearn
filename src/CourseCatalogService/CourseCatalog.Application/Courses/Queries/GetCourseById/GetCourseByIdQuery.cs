using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Queries.GetCourseById;

public record class GetCourseByIdQuery(CourseId CourseId)
    : IRequest<CourseResponse>;
