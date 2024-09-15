namespace CourseCatalog.Domain.Events;

public record class CourseStartDateChangedEvent(
    CourseId CourseId,
    DateTime NewStartDate) : IDomainEvent;
