namespace CourseCatalog.Application.Validators;

public class ChangeCoursePriceCommandValidator
    : AbstractValidator<ChangeCoursePriceCommand>
{
    public ChangeCoursePriceCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.NewPrice)
            .ChildRules(priceValidator =>
            {
                priceValidator.RuleFor(price => price.Currency)
                    .IsInEnum()
                    .WithMessage("Invalid currency.");
            });
    }
}
