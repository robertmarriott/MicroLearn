namespace CourseCatalog.Application.Commands;

public record class AddPrerequisiteCommand(
    CourseId CourseId,
    string Description) : IRequest<Prerequisite>;

public class AddPrerequisiteHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<AddPrerequisiteCommand, Prerequisite>
{
    public async Task<Prerequisite> Handle(
        AddPrerequisiteCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        var prerequisite = course.AddPrerequisite(request.Description);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return prerequisite;
    }
}
