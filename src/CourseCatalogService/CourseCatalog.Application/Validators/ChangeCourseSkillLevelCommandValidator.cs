using CourseCatalog.Application.Commands;
using FluentValidation;

namespace CourseCatalog.Application.Validators;

public class ChangeCourseSkillLevelCommandValidator
    : AbstractValidator<ChangeCourseSkillLevelCommand>
{
    public ChangeCourseSkillLevelCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.NewSkillLevel)
            .IsInEnum()
            .WithMessage("Invalid skill level.");
    }
}
