namespace CourseCatalog.Domain.Exceptions;

public class PrerequisiteNotFoundException(PrerequisiteId prerequisiteId)
    : DomainException($"Prerequisite with ID {prerequisiteId} not found.")
{
}
