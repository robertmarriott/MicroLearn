using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.AddCoursePrerequisite;

public class AddCoursePrerequisiteCommandValidator
    : AbstractValidator<AddCoursePrerequisiteCommand>
{
    public AddCoursePrerequisiteCommandValidator()
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
