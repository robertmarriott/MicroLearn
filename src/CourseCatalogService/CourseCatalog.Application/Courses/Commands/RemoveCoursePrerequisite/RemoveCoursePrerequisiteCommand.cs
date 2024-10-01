using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.RemoveCoursePrerequisite;

public record class RemoveCoursePrerequisiteCommand(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : IRequest<Unit>;
