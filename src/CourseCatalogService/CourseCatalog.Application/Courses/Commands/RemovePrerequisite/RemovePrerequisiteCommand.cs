using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.RemovePrerequisite;

public record class RemovePrerequisiteCommand(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : IRequest<Unit>;
