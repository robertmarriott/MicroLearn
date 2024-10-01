using CourseCatalog.Contracts.Common.Responses;
using CourseCatalog.Contracts.Instructors.Responses;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetAllInstructors;

public record class GetAllInstructorsQuery(int PageNumber, int PageSize)
    : IRequest<PaginatedResponse<InstructorResponse>>;
