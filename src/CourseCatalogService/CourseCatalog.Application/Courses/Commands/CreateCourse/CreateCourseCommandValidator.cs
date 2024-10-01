using CourseCatalog.Application.Common.Validators;
using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommandValidator
    : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(command => command.InstructorId.Value)
            .NotEmpty()
            .WithMessage("Instructor ID is required.");

        RuleFor(command => command.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(100)
            .WithMessage("Title cannot exceed 100 characters.");

        RuleFor(command => command.SkillLevel)
            .IsInEnum()
            .WithMessage("Invalid skill level.");

        RuleFor(command => command.Price).SetValidator(new PriceValidator());

        RuleFor(command => command.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

        RuleFor(command => command.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.");
    }
}
