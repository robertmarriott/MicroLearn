namespace CourseCatalog.Application.Commands;

public record class AddPrerequisiteCommand(
    CourseId CourseId, string Description) : IRequest<PrerequisiteId>;

public class AddPrerequisiteHandler(ICourseRepository courseRepository)
    : IRequestHandler<AddPrerequisiteCommand, PrerequisiteId>
{
    public async Task<PrerequisiteId> Handle(
        AddPrerequisiteCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId);

        if (course is null)
        {
            throw new Exception(""); // TODO: Create custom exception
        }

        return course.AddPrerequisite(request.Description);
    }
}
