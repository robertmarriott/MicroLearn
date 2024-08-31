namespace CourseCatalog.Domain.Courses.Entities;

public readonly record struct CourseId(Guid Value)
{
    public CourseId() : this(Guid.NewGuid()) { }
}
