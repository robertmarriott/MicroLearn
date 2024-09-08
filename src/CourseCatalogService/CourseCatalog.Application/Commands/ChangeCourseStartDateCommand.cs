namespace CourseCatalog.Application.Commands;

public record class ChangeCourseStartDateCommand(
    CourseId CourseId, DateOnly NewStartDate) : IRequest<Unit>;

public class ChangeCourseStartDateHandler(ICourseRepository courseRepository)
    : IRequestHandler<ChangeCourseStartDateCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseStartDateCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId);

        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        course.ChangeStartDate(request.NewStartDate);

        return Unit.Value;
    }
}
