namespace CourseCatalog.Domain.Common;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override int GetHashCode()
    {
        // HashMultiplier is a prime number that helps reduce hash collisions
        const int HashMultiplier = 31;

        return GetEqualityComponents().Aggregate(0, (hashCode, value) =>
            hashCode = hashCode * HashMultiplier ^ (value?.GetHashCode() ?? 0));
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(
            other.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left == right;
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }
}
