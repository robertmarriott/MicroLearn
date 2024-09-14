namespace CourseCatalog.Domain.ValueObjects;

public class CourseId : ValueObject
{
    public Guid Value { get; }

    private CourseId(Guid value)
    {
        Value = value;
    }

    public static CourseId CreateUnique()
    {
        return new CourseId(Guid.NewGuid());
    }

    public static CourseId Create(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return new CourseId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
