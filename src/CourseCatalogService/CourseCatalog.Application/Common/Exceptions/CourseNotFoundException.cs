using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Application.Common.Exceptions;

public class CourseNotFoundException(CourseId courseId)
    : Exception($"Course with ID {courseId} not found.")
{
}
