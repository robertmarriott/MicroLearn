namespace CourseCatalog.Application.Queries;

public record class GetAllInstructorsQuery()
    : IRequest<IReadOnlyList<InstructorResponse>>;

public class GetAllInstructorsQueryHandler(
    IInstructorRepository instructorRepository,
    IMapper mapper)
    : IRequestHandler<GetAllInstructorsQuery, IReadOnlyList<InstructorResponse>>
{
    public async Task<IReadOnlyList<InstructorResponse>> Handle(
        GetAllInstructorsQuery request,
        CancellationToken cancellationToken)
    {
        var instructors = await instructorRepository.GetAllAsync();

        return mapper.Map<IReadOnlyList<InstructorResponse>>(instructors);
    }
}
