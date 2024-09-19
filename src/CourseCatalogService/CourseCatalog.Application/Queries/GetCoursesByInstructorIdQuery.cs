
namespace CourseCatalog.Application.Queries;

public record class GetCoursesByInstructorIdQuery(InstructorId InstructorId)
    : IRequest<IReadOnlyList<CourseResponse>>;

public class GetCoursesByInstructorIdHandler(
    ICourseRepository courseRepository,
    IInstructorRepository instructorRepository,
    IMapper mapper)
    : IRequestHandler<GetCoursesByInstructorIdQuery, IReadOnlyList<CourseResponse>>
{
    public async Task<IReadOnlyList<CourseResponse>> Handle(
        GetCoursesByInstructorIdQuery request,
        CancellationToken cancellationToken)
    {
        var instructorExists = await instructorRepository
            .ExistsAsync(request.InstructorId);

        if (!instructorExists)
        {
            throw new InstructorNotFoundException(request.InstructorId);
        }

        var courses = await courseRepository
            .GetByInstructorIdAsync(request.InstructorId);

        return mapper.Map<IReadOnlyList<CourseResponse>>(courses);
    }
}
