namespace CourseCatalog.Application.Validators;

public class ChangeCourseTitleCommandValidator
    : AbstractValidator<ChangeCourseTitleCommand>
{
    public ChangeCourseTitleCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.NewTitle)
            .NotEmpty()
            .WithMessage("New title is required.")
            .MaximumLength(100)
            .WithMessage("New title cannot exceed 100 characters.");
    }
}
