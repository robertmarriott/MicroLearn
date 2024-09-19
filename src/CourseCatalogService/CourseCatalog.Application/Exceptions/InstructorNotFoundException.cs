namespace CourseCatalog.Application.Exceptions;

public class InstructorNotFoundException(InstructorId instructorId)
    : Exception($"Instructor with ID {instructorId} not found.")
{
}
