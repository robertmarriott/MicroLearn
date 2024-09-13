namespace CourseCatalog.Application.Validators;

public class ChangeCourseStartDateCommandValidator
    : AbstractValidator<ChangeCourseStartDateCommand>
{
    public ChangeCourseStartDateCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}
