using CourseCatalog.Domain.Common.Models;

namespace CourseCatalog.Domain.Courses.ValueObjects;

public class PrerequisiteId : ValueObject
{
    public Guid Value { get; }

    private PrerequisiteId(Guid value)
    {
        Value = value;
    }

    public static PrerequisiteId CreateUnique()
    {
        return new PrerequisiteId(Guid.NewGuid());
    }

    public static PrerequisiteId Create(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return new PrerequisiteId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
