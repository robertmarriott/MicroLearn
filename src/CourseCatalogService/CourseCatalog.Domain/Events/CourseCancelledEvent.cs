namespace CourseCatalog.Domain.Events;

public record class CourseCancelledEvent(
    CourseId CourseId,
    DateTime CancellationDate) : IDomainEvent;
