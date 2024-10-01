using CourseCatalog.Contracts.Instructors.Responses;
using CourseCatalog.Domain.Instructors.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Instructors.Queries.GetInstructorById;

public record class GetInstructorByIdQuery(InstructorId InstructorId)
    : IRequest<InstructorResponse>;
