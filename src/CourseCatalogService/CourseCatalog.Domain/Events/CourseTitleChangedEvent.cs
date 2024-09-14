namespace CourseCatalog.Domain.Events;

public record class CourseTitleChangedEvent(
    CourseId CourseId,
    string NewTitle) : IDomainEvent;
