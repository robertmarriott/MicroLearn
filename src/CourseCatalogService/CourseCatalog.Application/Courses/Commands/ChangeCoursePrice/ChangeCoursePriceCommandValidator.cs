using CourseCatalog.Application.Common.Validators;
using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.ChangeCoursePrice;

public class ChangeCoursePriceCommandValidator
    : AbstractValidator<ChangeCoursePriceCommand>
{
    public ChangeCoursePriceCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");

        RuleFor(command => command.NewPrice).SetValidator(new PriceValidator());
    }
}
