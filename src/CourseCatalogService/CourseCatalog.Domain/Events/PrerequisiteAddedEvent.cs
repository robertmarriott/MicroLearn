namespace CourseCatalog.Domain.Events;

public record class PrerequisiteAddedEvent(
    CourseId CourseId, PrerequisiteId PrerequisiteId) : IDomainEvent;
