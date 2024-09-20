namespace CourseCatalog.Application.Queries;

public record class GetCoursesOpenForEnrollmentQuery()
    : IRequest<IReadOnlyList<CourseResponse>>;

public class GetCoursesOpenForEnrollmentQueryHandler(
    ICourseRepository courseRepository,
    IMapper mapper)
    : IRequestHandler<GetCoursesOpenForEnrollmentQuery, IReadOnlyList<CourseResponse>>
{
    public async Task<IReadOnlyList<CourseResponse>> Handle(
        GetCoursesOpenForEnrollmentQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetOpenForEnrollmentAsync();

        return mapper.Map<IReadOnlyList<CourseResponse>>(courses);
    }
}
