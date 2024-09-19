namespace CourseCatalog.Application.Commands;

public record class AddPrerequisiteCommand(
    CourseId CourseId,
    string Description) : IRequest<PrerequisiteResponse>;

public class AddPrerequisiteHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<AddPrerequisiteCommand, PrerequisiteResponse>
{
    public async Task<PrerequisiteResponse> Handle(
        AddPrerequisiteCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        var prerequisite = course.AddPrerequisite(request.Description);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<PrerequisiteResponse>(prerequisite);
    }
}
