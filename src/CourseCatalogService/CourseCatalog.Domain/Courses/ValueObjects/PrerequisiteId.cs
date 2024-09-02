namespace CourseCatalog.Domain.Courses.ValueObjects;

public readonly record struct PrerequisiteId(Guid Value)
{
    public PrerequisiteId() : this(Guid.NewGuid()) { }
}
