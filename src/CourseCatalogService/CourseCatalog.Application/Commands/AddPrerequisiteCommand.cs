namespace CourseCatalog.Application.Commands;

public record class AddPrerequisiteCommand(
    CourseId CourseId, string Description) : IRequest<PrerequisiteId>;

public class AddPrerequisiteHandler(ICourseRepository courseRepository)
    : IRequestHandler<AddPrerequisiteCommand, PrerequisiteId>
{
    public async Task<PrerequisiteId> Handle(
        AddPrerequisiteCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        return course.AddPrerequisite(request.Description);
    }
}
