namespace CourseCatalog.Application.Exceptions;

public class CourseNotFoundException(CourseId courseId)
    : Exception($"Course with ID {courseId} not found.")
{
}
