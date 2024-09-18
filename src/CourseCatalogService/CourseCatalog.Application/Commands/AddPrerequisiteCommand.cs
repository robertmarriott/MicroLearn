namespace CourseCatalog.Application.Commands;

public record class AddPrerequisiteCommand(
    CourseId CourseId,
    string Description) : IRequest<PrerequisiteId>;

public class AddPrerequisiteHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<AddPrerequisiteCommand, PrerequisiteId>
{
    public async Task<PrerequisiteId> Handle(
        AddPrerequisiteCommand request,
        CancellationToken cancellationToken = default)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        var prerequisiteId = course.AddPrerequisite(request.Description);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return prerequisiteId;
    }
}
