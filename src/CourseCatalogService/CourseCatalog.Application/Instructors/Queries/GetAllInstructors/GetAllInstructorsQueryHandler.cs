using AutoMapper;
using CourseCatalog.Contracts.Instructors.Responses;
using CourseCatalog.Domain.Instructors;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetAllInstructors;

public class GetAllInstructorsQueryHandler(
    IInstructorRepository instructorRepository,
    IMapper mapper)
    : IRequestHandler<GetAllInstructorsQuery, IReadOnlyList<InstructorResponse>>
{
    public async Task<IReadOnlyList<InstructorResponse>> Handle(
        GetAllInstructorsQuery request,
        CancellationToken cancellationToken)
    {
        var instructors = await instructorRepository.ListAsync(
            request.PageNumber, request.PageSize);

        return mapper.Map<IReadOnlyList<InstructorResponse>>(instructors);
    }
}
