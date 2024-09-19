
namespace CourseCatalog.Application.Queries;

public record class GetCoursesByInstructorIdQuery(InstructorId InstructorId)
    : IRequest<IReadOnlyList<CourseResponse>>;

public class GetCoursesByInstructorIdHandler(
    ICourseRepository courseRepository,
    IMapper mapper)
    : IRequestHandler<GetCoursesByInstructorIdQuery, IReadOnlyList<CourseResponse>>
{
    public async Task<IReadOnlyList<CourseResponse>> Handle(
        GetCoursesByInstructorIdQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await courseRepository
            .GetByInstructorIdAsync(request.InstructorId);

        return mapper.Map<IReadOnlyList<CourseResponse>>(courses);
    }
}
