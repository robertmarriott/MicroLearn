namespace CourseCatalog.Domain.Courses.Entities;

public readonly record struct CourseModuleId(Guid Value)
{
    public CourseModuleId() : this(Guid.NewGuid()) { }
}
