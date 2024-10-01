using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.RemovePrerequisite;

public class RemovePrerequisiteCommandValidator
    : AbstractValidator<RemovePrerequisiteCommand>
{
    public RemovePrerequisiteCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.PrerequisiteId.Value)
            .NotEmpty()
            .WithMessage("Prerequisite ID is required.");
    }
}
