using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.RemoveCoursePrerequisite;

public class RemoveCoursePrerequisiteCommandValidator
    : AbstractValidator<RemoveCoursePrerequisiteCommand>
{
    public RemoveCoursePrerequisiteCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.PrerequisiteId.Value)
            .NotEmpty()
            .WithMessage("Prerequisite ID is required.");
    }
}
