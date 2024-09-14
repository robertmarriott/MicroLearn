namespace CourseCatalog.Application.Validators;

public class CreateCourseCommandValidator
    : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.InstructorId.Value)
            .NotEmpty()
            .WithMessage("Instructor ID is required.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100)
            .WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.SkillLevel)
            .IsInEnum()
            .WithMessage("Invalid skill level.");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.");

        RuleFor(x => x.Price)
            .ChildRules(price =>
            {
                price.RuleFor(p => p.Currency)
                    .IsInEnum()
                    .WithMessage("Invalid currency.");
            });
    }
}
