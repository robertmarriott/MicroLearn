namespace CourseCatalog.Application.Commands;

public record class CreateCourseCommand(
    InstructorId InstructorId,
    string Title,
    SkillLevel SkillLevel,
    Price Price,
    DateTime StartDate,
    DateTime EndDate) : IRequest<Course>;

public class CreateCourseHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCourseCommand, Course>
{
    public async Task<Course> Handle(
        CreateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var course = Course.Create(
            request.InstructorId,
            request.Title,
            request.SkillLevel,
            request.Price,
            request.StartDate,
            request.EndDate);

        await courseRepository.AddAsync(course);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return course;
    }
}
