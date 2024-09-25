﻿using SharedKernel.Domain;

namespace CourseCatalog.Application.Commands;

public record class ChangeCourseStartDateCommand(
    CourseId CourseId,
    DateTime NewStartDate) : IRequest<Unit>;

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
