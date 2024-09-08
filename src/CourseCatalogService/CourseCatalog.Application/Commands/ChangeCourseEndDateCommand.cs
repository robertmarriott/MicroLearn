namespace CourseCatalog.Application.Commands;

public record class ChangeCourseEndDateCommand(
    CourseId CourseId, DateOnly NewEndDate) : IRequest<Unit>;

public class ChangeCourseEndDateHandler(ICourseRepository courseRepository)
    : IRequestHandler<ChangeCourseEndDateCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseEndDateCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId);

        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        course.ChangeEndDate(request.NewEndDate);

        return Unit.Value;
    }
}
