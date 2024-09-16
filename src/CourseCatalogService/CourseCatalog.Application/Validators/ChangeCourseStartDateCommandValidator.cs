namespace CourseCatalog.Application.Validators;

public class ChangeCourseStartDateCommandValidator
    : AbstractValidator<ChangeCourseStartDateCommand>
{
    public ChangeCourseStartDateCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.NewStartDate)
            .NotEmpty()
            .WithMessage("New start date is required.");
    }
}
