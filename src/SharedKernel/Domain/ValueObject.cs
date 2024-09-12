namespace SharedKernel.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override int GetHashCode()
    {
        const int HashMultiplier = 31;

        return GetEqualityComponents()
            .Aggregate(0, (hash, value) =>
                hash * HashMultiplier ^ (value?.GetHashCode() ?? 0));
    }

    public bool Equals(ValueObject? other)
    {
        return other is not null && Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other
            && GetEqualityComponents().SequenceEqual(
                other.GetEqualityComponents());
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
