using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.CancelCourse;

public class CancelCourseCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CancelCourseCommand, Unit>
{
    public async Task<Unit> Handle(
        CancelCourseCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.Cancel();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
