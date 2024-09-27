namespace CourseCatalog.Domain.Common.Base;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull
{
    public TId Id { get; protected init; }

#pragma warning disable CS8618
    protected Entity() { }
#pragma warning restore CS8618

    protected Entity(TId id) : this()
    {
        Id = id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> other && Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return left is null ? right is null : left.Equals(right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }
}
