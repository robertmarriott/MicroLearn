namespace CourseCatalog.Domain.Common.Base;

public abstract class ValueObject : IEquatable<ValueObject>
{
    private const int HashMultiplier = 31;

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override int GetHashCode()
    {
        return GetEqualityComponents().Aggregate(0, (hash, value) =>
            hash * HashMultiplier ^ (value?.GetHashCode() ?? 0));
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other
            && GetEqualityComponents()
                .SequenceEqual(other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }
}
