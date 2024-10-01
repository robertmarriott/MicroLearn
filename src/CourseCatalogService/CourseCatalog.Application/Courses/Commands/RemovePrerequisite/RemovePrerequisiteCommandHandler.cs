using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.RemovePrerequisite;

public class RemovePrerequisiteCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemovePrerequisiteCommand, Unit>
{
    public async Task<Unit> Handle(
        RemovePrerequisiteCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.RemovePrerequisite(request.PrerequisiteId);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
