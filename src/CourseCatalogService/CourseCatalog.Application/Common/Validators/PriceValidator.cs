using CourseCatalog.Domain.Courses.ValueObjects;
using FluentValidation;

namespace CourseCatalog.Application.Common.Validators;

public class PriceValidator : AbstractValidator<Price>
{
    public PriceValidator()
    {
        RuleFor(price => price.Currency)
            .IsInEnum()
            .WithMessage("Invalid currency.");
    }
}
