using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Application.Common.Exceptions;

public class CourseNotFoundException(CourseId courseId)
    : ApplicationException($"Course with ID {courseId} not found.")
{
}
