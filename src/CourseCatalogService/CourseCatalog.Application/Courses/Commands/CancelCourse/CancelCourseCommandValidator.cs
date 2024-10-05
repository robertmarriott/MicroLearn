using FluentValidation;

namespace CourseCatalog.Application.Courses.Commands.CancelCourse;

public class CancelCourseCommandValidator
    : AbstractValidator<CancelCourseCommand>
{
    public CancelCourseCommandValidator()
    {
        RuleFor(command => command.CourseId.Value)
            .NotEmpty()
            .WithMessage("Course ID is required.");
    }
}
