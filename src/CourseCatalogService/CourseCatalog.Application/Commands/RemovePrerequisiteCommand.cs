namespace CourseCatalog.Application.Commands;

public record class RemovePrerequisiteCommand(
    CourseId CourseId, PrerequisiteId PrerequisiteId) : IRequest;
