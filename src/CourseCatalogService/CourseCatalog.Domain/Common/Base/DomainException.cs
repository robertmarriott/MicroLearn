namespace CourseCatalog.Domain.Common.Models;

public class DomainException(string message) : Exception(message)
{
}
