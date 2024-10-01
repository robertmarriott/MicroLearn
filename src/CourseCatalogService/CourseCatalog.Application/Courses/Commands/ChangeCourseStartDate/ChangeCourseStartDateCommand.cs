using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.ChangeCourseStartDate;

public record class ChangeCourseStartDateCommand(
    CourseId CourseId,
    DateTime NewStartDate) : IRequest<Unit>;
