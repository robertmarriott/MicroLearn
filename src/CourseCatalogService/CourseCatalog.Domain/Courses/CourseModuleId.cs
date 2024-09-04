namespace CourseCatalog.Domain.Courses;

public readonly record struct CourseModuleId(Guid Value)
{
    public CourseModuleId() : this(Guid.NewGuid()) { }
}
