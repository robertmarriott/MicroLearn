namespace CourseCatalog.Domain.Courses;

public readonly record struct CourseId(Guid Value)
{
    public CourseId() : this(Guid.NewGuid()) { }
}
