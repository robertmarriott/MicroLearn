namespace CourseCatalog.Application.Commands;

public record class RemovePrerequisiteCommand(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : IRequest<Unit>;

public class RemovePrerequisiteHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<RemovePrerequisiteCommand, Unit>
{
    public async Task<Unit> Handle(
        RemovePrerequisiteCommand request,
        CancellationToken cancellationToken = default)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.RemovePrerequisite(request.PrerequisiteId);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
