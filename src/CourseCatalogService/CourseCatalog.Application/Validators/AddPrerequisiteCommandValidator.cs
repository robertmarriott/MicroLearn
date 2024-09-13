namespace CourseCatalog.Application.Validators;

public class AddPrerequisiteCommandValidator
    : AbstractValidator<AddPrerequisiteCommand>
{
    public AddPrerequisiteCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage(
                "Description cannot exceed 500 characters.");
    }
}
