namespace CourseCatalog.Application.Validators;

public class ChangeCourseEndDateCommandValidator
    : AbstractValidator<ChangeCourseEndDateCommand>
{
    public ChangeCourseEndDateCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");
    }
}
