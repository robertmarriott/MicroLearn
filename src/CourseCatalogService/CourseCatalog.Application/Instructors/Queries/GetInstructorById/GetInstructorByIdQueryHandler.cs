using AutoMapper;
using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Contracts.Instructors.Responses;
using CourseCatalog.Domain.Instructors;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetInstructorById;

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
