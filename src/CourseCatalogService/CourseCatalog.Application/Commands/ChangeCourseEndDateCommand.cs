namespace CourseCatalog.Application.Commands;

public record class ChangeCourseEndDateCommand(
    CourseId CourseId,
    DateTime NewEndDate) : IRequest<Unit>;

public class ChangeCourseEndDateCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ChangeCourseEndDateCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseEndDateCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangeEndDate(request.NewEndDate);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
