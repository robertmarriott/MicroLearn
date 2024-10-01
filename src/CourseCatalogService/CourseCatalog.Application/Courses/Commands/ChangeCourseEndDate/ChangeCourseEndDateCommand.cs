using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.ChangeCourseEndDate;

public record class ChangeCourseEndDateCommand(
    CourseId CourseId,
    DateTime NewEndDate) : IRequest<Unit>;
