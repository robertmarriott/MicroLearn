namespace CourseCatalog.Domain.Exceptions;

public class ModuleNotFoundException(ModuleId moduleId)
    : Exception($"Module with ID {moduleId} not found.")
{
}
