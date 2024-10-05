using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.CancelCourse;

public record class CancelCourseCommand(CourseId CourseId) : IRequest<Unit>;
