namespace CourseCatalog.Application.Validators;

public class ChangeCourseStartDateCommandValidator
    : AbstractValidator<ChangeCourseStartDateCommand>
{
    public ChangeCourseStartDateCommandValidator()
    {
        RuleFor(x => x.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(x => x.NewStartDate)
            .NotEmpty()
            .WithMessage("New start date is required.");
    }
}
