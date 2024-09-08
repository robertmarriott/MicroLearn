
namespace CourseCatalog.Application.Commands;

public record class ChangeCourseTitleCommand(
    CourseId CourseId, string NewTitle) : IRequest<Unit>;

public class ChangeCourseTitleHandler(ICourseRepository courseRepository)
    : IRequestHandler<ChangeCourseTitleCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseTitleCommand request, CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId);

        if (course is null)
        {
            throw new CourseNotFoundException(request.CourseId);
        }

        course.ChangeTitle(request.NewTitle);

        return Unit.Value;
    }
}
