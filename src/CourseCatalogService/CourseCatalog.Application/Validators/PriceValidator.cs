namespace CourseCatalog.Application.Validators;

public class PriceValidator : AbstractValidator<Price>
{
    public PriceValidator()
    {
        RuleFor(price => price.Currency)
            .IsInEnum()
            .WithMessage("Invalid currency.");
    }
}
