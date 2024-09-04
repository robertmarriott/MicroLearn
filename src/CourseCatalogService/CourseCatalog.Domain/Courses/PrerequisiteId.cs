namespace CourseCatalog.Domain.Courses;

public readonly record struct PrerequisiteId(Guid Value)
{
    public PrerequisiteId() : this(Guid.NewGuid()) { }
}
