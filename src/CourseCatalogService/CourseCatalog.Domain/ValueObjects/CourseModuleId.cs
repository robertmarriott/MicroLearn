namespace CourseCatalog.Domain.ValueObjects;

public readonly record struct CourseModuleId(Guid Value)
{
    public CourseModuleId() : this(Guid.NewGuid()) { }
}
