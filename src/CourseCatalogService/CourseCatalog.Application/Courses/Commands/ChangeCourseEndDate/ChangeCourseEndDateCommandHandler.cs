using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.ChangeCourseEndDate;

public class ChangeCourseEndDateCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ChangeCourseEndDateCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCourseEndDateCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangeEndDate(request.NewEndDate);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
