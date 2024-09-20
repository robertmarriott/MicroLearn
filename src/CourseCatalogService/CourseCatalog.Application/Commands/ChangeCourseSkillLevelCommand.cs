namespace CourseCatalog.Application.Commands;

public record class ChangeCourseSkillLevelCommand(
    CourseId CourseId,
    SkillLevel NewSkillLevel) : IRequest<Unit>;

public class ChangeCourseSkillLevelCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeCourseSkillLevelCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseSkillLevelCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangeSkillLevel(request.NewSkillLevel);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
