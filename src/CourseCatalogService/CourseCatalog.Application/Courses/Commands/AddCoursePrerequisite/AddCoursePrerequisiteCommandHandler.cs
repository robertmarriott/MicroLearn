using AutoMapper;
using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.AddCoursePrerequisite;

public class AddCoursePrerequisiteCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<AddCoursePrerequisiteCommand, CoursePrerequisiteResponse>
{
    public async Task<CoursePrerequisiteResponse> Handle(
        AddCoursePrerequisiteCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        var prerequisite = course.AddPrerequisite(request.Description);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<CoursePrerequisiteResponse>(prerequisite);
    }
}
