using MediatR;

namespace CourseCatalog.Domain.Common.Models;

public abstract record class DomainEvent : INotification
{
    public DateTime EventDate { get; } = DateTime.UtcNow;
}
