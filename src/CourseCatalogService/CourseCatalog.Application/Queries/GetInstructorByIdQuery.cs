namespace CourseCatalog.Application.Queries;

public record class GetInstructorByIdQuery(InstructorId InstructorId)
    : IRequest<InstructorResponse>;

public class GetInstructorByIdQueryHandler(
    IInstructorRepository instructorRepository,
    IMapper mapper)
    : IRequestHandler<GetInstructorByIdQuery, InstructorResponse>
{
    public async Task<InstructorResponse> Handle(
        GetInstructorByIdQuery request,
        CancellationToken cancellationToken)
    {
        var instructor = await instructorRepository
            .GetByIdAsync(request.InstructorId)
            ?? throw new InstructorNotFoundException(request.InstructorId);

        return mapper.Map<InstructorResponse>(instructor);
    }
}
