namespace CourseCatalog.Application.Commands;

public record class RemovePrerequisiteCommand(
    CourseId CourseId, PrerequisiteId PrerequisiteId) : IRequest;

public class RemovePrerequisiteHandler(ICourseRepository courseRepository)
    : IRequestHandler<RemovePrerequisiteCommand>
{
    public async Task Handle(
        RemovePrerequisiteCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId);

        if (course is null)
        {
            throw new Exception(""); // TODO: Create custom exception
        }

        course.RemovePrerequisite(request.PrerequisiteId);
    }
}
