namespace CourseCatalog.Application.Commands;

public record class ChangeCoursePriceCommand(
    CourseId CourseId,
    Price NewPrice) : IRequest<Unit>;

public class ChangeCoursePriceHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ChangeCoursePriceCommand, Unit>
{
    public async Task<Unit> Handle(
        ChangeCoursePriceCommand request,
        CancellationToken cancellationToken = default)
    {
        var course = await courseRepository.GetByIdAsync(request.CourseId)
            ?? throw new CourseNotFoundException(request.CourseId);

        course.ChangePrice(request.NewPrice);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
