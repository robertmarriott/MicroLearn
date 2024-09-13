namespace CourseCatalog.Application.Validators;

public class ChangeCourseTitleCommandValidator
    : AbstractValidator<ChangeCourseTitleCommand>
{
    public ChangeCourseTitleCommandValidator()
    {
        RuleFor(x => x.NewTitle)
            .NotEmpty().WithMessage("New title is required.")
            .MaximumLength(100).WithMessage(
                "New title cannot exceed 100 characters.");
    }
}
