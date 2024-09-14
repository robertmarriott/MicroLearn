namespace CourseCatalog.Application.Validators;

public class ChangeCoursePriceCommandValidator
    : AbstractValidator<ChangeCoursePriceCommand>
{
    public ChangeCoursePriceCommandValidator()
    {
        RuleFor(x => x.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(x => x.NewPrice)
            .ChildRules(price =>
            {
                price.RuleFor(p => p.Currency)
                    .IsInEnum()
                    .WithMessage("Invalid currency.");
            });
    }
}
