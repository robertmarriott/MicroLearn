namespace CourseCatalog.Application.Validators;

public class ChangeCourseEndDateCommandValidator
    : AbstractValidator<ChangeCourseEndDateCommand>
{
    public ChangeCourseEndDateCommandValidator()
    {
        RuleFor(x => x.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(x => x.NewEndDate)
            .NotEmpty()
            .WithMessage("New end date is required.");
    }
}
