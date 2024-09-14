namespace CourseCatalog.Application.Validators;

public class ChangeCourseSkillLevelCommandValidator
    : AbstractValidator<ChangeCourseSkillLevelCommand>
{
    public ChangeCourseSkillLevelCommandValidator()
    {
        RuleFor(x => x.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(x => x.NewSkillLevel)
            .IsInEnum()
            .WithMessage("Invalid skill level.");
    }
}
