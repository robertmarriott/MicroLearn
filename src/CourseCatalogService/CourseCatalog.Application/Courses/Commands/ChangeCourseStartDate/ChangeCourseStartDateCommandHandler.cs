using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.ChangeCourseStartDate;

public class ChangeCourseStartDateCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeCourseStartDateCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseStartDateCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangeStartDate(request.NewStartDate);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
