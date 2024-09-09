namespace CourseCatalog.Domain.Events;

public record class CoursePriceChangedEvent(
    CourseId CourseId, Price NewPrice) : IDomainEvent;
