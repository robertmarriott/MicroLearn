namespace CourseCatalog.Application.Commands;

public record class CreateCourseCommand(
    InstructorId InstructorId,
    string Title,
    SkillLevel SkillLevel,
    Price Price,
    DateTime StartDate,
    DateTime EndDate) : IRequest<CourseResponse>;

public class CreateCourseCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateCourseCommand, CourseResponse>
{
    public async Task<CourseResponse> Handle(
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

        return mapper.Map<CourseResponse>(course);
    }
}
