namespace CourseCatalog.Domain.ValueObjects;

public readonly record struct CourseId(Guid Value)
{
    public CourseId() : this(Guid.NewGuid()) { }
}
