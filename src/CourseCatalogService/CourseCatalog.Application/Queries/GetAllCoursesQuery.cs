namespace CourseCatalog.Application.Queries;

public record class GetAllCoursesQuery() : IRequest<GetAllCoursesResponse>;

public class GetAllCoursesHandler(
    ICourseRepository courseRepository,
    IMapper mapper) : IRequestHandler<GetAllCoursesQuery, GetAllCoursesResponse>
{
    public async Task<GetAllCoursesResponse> Handle(
        GetAllCoursesQuery request,
        CancellationToken cancellationToken)
    {
        var courses = await courseRepository.GetAllAsync();

        return new GetAllCoursesResponse(mapper.Map<List<CourseDto>>(courses));
    }
}
