namespace CourseCatalog.Application.Commands;

public record class ChangeCourseTitleCommand(
    CourseId CourseId,
    string NewTitle) : IRequest<Unit>;

public class ChangeCourseTitleHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeCourseTitleCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseTitleCommand request,
        CancellationToken cancellationToken = default)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangeTitle(request.NewTitle);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
