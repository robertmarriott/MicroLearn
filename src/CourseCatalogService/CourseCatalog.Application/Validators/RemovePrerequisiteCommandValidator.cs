namespace CourseCatalog.Application.Validators;

public class RemovePrerequisiteCommandValidator
    : AbstractValidator<RemovePrerequisiteCommand>
{
    public RemovePrerequisiteCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");

        RuleFor(x => x.PrerequisiteId)
            .NotEmpty().WithMessage("Prerequisite ID is required.");
    }
}
