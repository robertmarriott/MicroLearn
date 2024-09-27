using CourseCatalog.Domain.Common.Models;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Exceptions;

public class PrerequisiteNotFoundException(PrerequisiteId prerequisiteId)
    : DomainException($"Prerequisite with ID {prerequisiteId} not found.")
{
}
