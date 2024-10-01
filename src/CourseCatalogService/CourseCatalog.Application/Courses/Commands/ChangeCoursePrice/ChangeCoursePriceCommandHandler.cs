using CourseCatalog.Application.Common.Exceptions;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.ChangeCoursePrice;

public class ChangeCoursePriceCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ChangeCoursePriceCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCoursePriceCommand request,
        CancellationToken cancellationToken)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangePrice(request.NewPrice);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
