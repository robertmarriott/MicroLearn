namespace CourseCatalog.Application.Validators;

public class AddPrerequisiteCommandValidator
    : AbstractValidator<AddPrerequisiteCommand>
{
    public AddPrerequisiteCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description cannot exceed 500 characters.");
    }
}
