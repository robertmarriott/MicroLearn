namespace CourseCatalog.Application.Validators;

public class RemovePrerequisiteCommandValidator
    : AbstractValidator<RemovePrerequisiteCommand>
{
    public RemovePrerequisiteCommandValidator()
    {
        RuleFor(x => x.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(x => x.PrerequisiteId.Value)
            .NotEmpty()
            .WithMessage("Prerequisite ID is required.");
    }
}
