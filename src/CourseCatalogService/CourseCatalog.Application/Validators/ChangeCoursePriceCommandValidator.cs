namespace CourseCatalog.Application.Validators;

public class ChangeCoursePriceCommandValidator
    : AbstractValidator<ChangeCoursePriceCommand>
{
    public ChangeCoursePriceCommandValidator()
    {
        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("Course ID is required.");

        RuleFor(x => x.NewPrice)
            .NotNull().WithMessage("New price is required.")
            .ChildRules(price =>
            {
                price.RuleFor(p => p.Amount)
                    .GreaterThanOrEqualTo(0).WithMessage(
                        "Amount must be non-negative.");

                price.RuleFor(p => p.Currency)
                    .IsInEnum().WithMessage("Invalid currency.");
            });
    }
}
