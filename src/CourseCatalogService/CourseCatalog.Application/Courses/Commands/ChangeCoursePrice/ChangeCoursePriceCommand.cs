using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.ChangeCoursePrice;

public record class ChangeCoursePriceCommand(
    CourseId CourseId,
    Price NewPrice) : IRequest<Unit>;
