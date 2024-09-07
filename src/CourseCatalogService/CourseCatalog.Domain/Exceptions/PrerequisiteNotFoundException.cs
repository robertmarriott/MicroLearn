namespace CourseCatalog.Domain.Exceptions;

public class PrerequisiteNotFoundException(PrerequisiteId prerequisiteId)
    : Exception($"Prerequisite with ID {prerequisiteId} not found.")
{
}
