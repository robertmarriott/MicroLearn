using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.AddCoursePrerequisite;

public record class AddCoursePrerequisiteCommand(
    CourseId CourseId,
    string Description) : IRequest<CoursePrerequisiteResponse>;
