namespace CourseCatalog.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }

    private readonly List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents =>
        _domainEvents.AsReadOnly();

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreateDate = DateTime.UtcNow;
        LastUpdateDate = DateTime.UtcNow;
    }

    public void UpdateTimestamp()
    {
        LastUpdateDate = DateTime.UtcNow;
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (Entity)obj;

        return Id == other.Id;
    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null)
        {
            return false;
        }

        return left.Id == right.Id;
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}
