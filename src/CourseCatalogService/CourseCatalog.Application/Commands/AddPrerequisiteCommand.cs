
namespace CourseCatalog.Application.Commands;

public record class AddPrerequisiteCommand(
    CourseId CourseId, string Description) : IRequest;

public class AddPrerequisiteHandler(ICourseRepository repository)
    : IRequestHandler<AddPrerequisiteCommand>
{
    public async Task Handle(
        AddPrerequisiteCommand request, CancellationToken cancellationToken)
    {
        var course = await repository.GetByIdAsync(request.CourseId);

        course?.AddPrerequisite(
            Prerequisite.Create(course.Id, request.Description));
    }
}
