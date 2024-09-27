using CourseCatalog.Domain.Common.Base;

namespace CourseCatalog.Domain.Instructors.ValueObjects;

public class InstructorId : ValueObject
{
    public Guid Value { get; }

    private InstructorId(Guid value)
    {
        Value = value;
    }

    public static InstructorId CreateUnique()
    {
        return new InstructorId(Guid.NewGuid());
    }

    public static InstructorId Create(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        return new InstructorId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
