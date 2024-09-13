namespace CourseCatalog.Application.Validators;

public class CreateCourseCommandValidator
    : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100)
            .WithMessage("Title cannot exceed 100 characters.");

        RuleFor(x => x.SkillLevel)
            .IsInEnum()
            .WithMessage("Invalid skill level.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow))
            .WithMessage("Start date must be in the future.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date must be after the start date.");

        RuleFor(x => x.Price)
            .ChildRules(price =>
            {
                price.RuleFor(p => p.Amount)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Amount must be non-negative.");

                price.RuleFor(p => p.Currency)
                    .IsInEnum()
                    .WithMessage("Invalid currency.");
            });
    }
}
