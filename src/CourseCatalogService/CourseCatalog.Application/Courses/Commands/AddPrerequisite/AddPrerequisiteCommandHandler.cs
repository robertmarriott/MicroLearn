using AutoMapper;
using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.AddPrerequisite;

public class AddPrerequisiteCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<AddPrerequisiteCommand, PrerequisiteResponse>
{
    public async Task<PrerequisiteResponse> Handle(
        AddPrerequisiteCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        var prerequisite = course.AddPrerequisite(request.Description);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<PrerequisiteResponse>(prerequisite);
    }
}
