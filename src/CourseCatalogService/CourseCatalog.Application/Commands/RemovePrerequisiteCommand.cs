namespace CourseCatalog.Application.Commands;

public record class RemovePrerequisiteCommand(
    CourseId CourseId, PrerequisiteId PrerequisiteId) : IRequest<Unit>;

public class RemovePrerequisiteHandler(ICourseRepository courseRepository)
    : IRequestHandler<RemovePrerequisiteCommand, Unit>
{
    public async Task<Unit> Handle(
        RemovePrerequisiteCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId);

        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        course.RemovePrerequisite(request.PrerequisiteId);

        return Unit.Value;
    }
}
