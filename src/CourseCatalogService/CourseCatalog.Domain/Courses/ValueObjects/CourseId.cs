namespace CourseCatalog.Domain.Courses.ValueObjects;

public readonly record struct CourseId(Guid Value)
{
    public CourseId() : this(Guid.NewGuid()) { }
}
