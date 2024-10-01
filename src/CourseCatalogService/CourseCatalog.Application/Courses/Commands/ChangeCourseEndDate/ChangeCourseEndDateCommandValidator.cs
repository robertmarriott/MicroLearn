using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.ChangeCourseEndDate;

public class ChangeCourseEndDateCommandValidator
    : AbstractValidator<ChangeCourseEndDateCommand>
{
    public ChangeCourseEndDateCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.NewEndDate)
            .NotEmpty()
            .WithMessage("New end date is required.");
    }
}
