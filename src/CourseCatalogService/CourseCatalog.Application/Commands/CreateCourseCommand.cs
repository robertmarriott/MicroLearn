namespace CourseCatalog.Application.Commands;

public record class CreateCourseCommand(
    InstructorId InstructorId,
    string Title,
    string Description,
    DateOnly StartDate,
    DateOnly EndDate) : IRequest<CourseId>;

public class CreateCourseHandler(ICourseRepository courseRepository)
    : IRequestHandler<CreateCourseCommand, CourseId>
{
    public async Task<CourseId> Handle(
        CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = Course.Create(
            request.InstructorId,
            request.Title,
            request.Description,
            request.StartDate,
            request.EndDate);

        await courseRepository.AddAsync(course);

        return course.Id;
    }
}
