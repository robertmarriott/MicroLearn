using MediatR;

namespace CourseCatalog.Domain.Common.Base;

public abstract record class DomainEvent : INotification
{
    public DateTime EventDate { get; } = DateTime.UtcNow;
}
