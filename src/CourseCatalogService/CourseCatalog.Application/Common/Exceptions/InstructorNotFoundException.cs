using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Application.Common.Exceptions;

public class InstructorNotFoundException(InstructorId instructorId)
    : ApplicationException($"Instructor with ID {instructorId} not found.")
{
}
