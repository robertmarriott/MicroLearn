namespace CourseCatalog.Domain.Events;

public record class CourseStartDateChangedEvent(
    CourseId CourseId,
    DateOnly NewStartDate) : IDomainEvent;
