namespace CourseCatalog.Application.Queries;

public record class GetAllCoursesQuery()
    : IRequest<IReadOnlyList<CourseResponse>>;

public class GetAllCoursesHandler(
    ICourseRepository courseRepository,
    IMapper mapper)
    : IRequestHandler<GetAllCoursesQuery, IReadOnlyList<CourseResponse>>
{
    public async Task<IReadOnlyList<CourseResponse>> Handle(
        GetAllCoursesQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetAllAsync();

        return mapper.Map<IReadOnlyList<CourseResponse>>(courses);
    }
}
