namespace CourseCatalog.Application.Validators;

public class ChangeCourseSkillLevelCommandValidator
    : AbstractValidator<ChangeCourseSkillLevelCommand>
{
    public ChangeCourseSkillLevelCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");

        RuleFor(x => x.NewSkillLevel)
            .IsInEnum().WithMessage("Invalid new skill level.");
    }
}
