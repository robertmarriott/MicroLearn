using AutoMapper;
using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Instructors.Responses;
using CourseCatalog.Domain.Instructors;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetAllInstructors;

public class GetAllInstructorsQueryHandler(
    IInstructorRepository instructorRepository,
    IMapper mapper)
    : IRequestHandler<GetAllInstructorsQuery, PaginatedResponse<InstructorResponse>>
{
    public async Task<PaginatedResponse<InstructorResponse>> Handle(
        GetAllInstructorsQuery request,
        CancellationToken cancellationToken)
    {
        var instructors = await instructorRepository.ListAsync(
            request.PageNumber, request.PageSize);

        var instructorResponses = mapper.Map<IReadOnlyList<InstructorResponse>>(
            instructors);

        var totalCount = await instructorRepository.CountAsync();

        return new PaginatedResponse<InstructorResponse>(
            instructorResponses,
            totalCount,
            request.PageNumber,
            request.PageSize);
    }
}
