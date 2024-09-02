namespace CourseCatalog.Domain.Courses.ValueObjects;

public readonly record struct CourseModuleId(Guid Value)
{
    public CourseModuleId() : this(Guid.NewGuid()) { }
}
