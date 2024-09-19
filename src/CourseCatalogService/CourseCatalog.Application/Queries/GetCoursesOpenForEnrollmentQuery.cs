namespace CourseCatalog.Application.Queries;

public record class GetCoursesOpenForEnrollment()
    : IRequest<GetCoursesOpenForEnrollmentResponse>;

public class GetCoursesOpenForEnrollmentHandler(
    ICourseRepository courseRepository,
    IMapper mapper)
    : IRequestHandler<GetCoursesOpenForEnrollmentQuery, GetCoursesOpenForEnrollmentResponse>
{
    public async Task<GetCoursesOpenForEnrollmentResponse> Handle(
        GetCoursesOpenForEnrollmentQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetOpenForEnrollmentAsync();

        return new GetCoursesOpenForEnrollmentResponse(
            mapper.Map<IReadOnlyList<CourseResponse>>(courses));
    }
}
