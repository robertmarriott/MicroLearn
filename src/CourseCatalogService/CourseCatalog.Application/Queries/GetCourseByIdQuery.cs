namespace CourseCatalog.Application.Queries;

public record class GetCourseByIdQuery(CourseId CourseId)
    : IRequest<GetCourseByIdResponse>;

public class GetCourseByIdHandler(
    ICourseRepository courseRepository,
    IMapper mapper) : IRequestHandler<GetCourseByIdQuery, GetCourseByIdResponse>
{
    public async Task<GetCourseByIdResponse> Handle(
        GetCourseByIdQuery request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        return new GetCourseByIdResponse(mapper.Map<CourseResponse>(course));
    }
}
