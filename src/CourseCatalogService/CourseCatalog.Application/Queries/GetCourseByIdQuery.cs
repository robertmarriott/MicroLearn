namespace CourseCatalog.Application.Queries;

public record class GetCourseByIdQuery(CourseId CourseId)
    : IRequest<CourseResponse>;

public class GetCourseByIdQueryHandler(
    ICourseRepository courseRepository,
    IMapper mapper) : IRequestHandler<GetCourseByIdQuery, CourseResponse>
{
    public async Task<CourseResponse> Handle(
        GetCourseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        return mapper.Map<CourseResponse>(course);
    }
}
