namespace CourseCatalog.Domain.Courses.Entities;

public readonly record struct PrerequisiteId(Guid Value)
{
    public PrerequisiteId() : this(Guid.NewGuid()) { }
}
