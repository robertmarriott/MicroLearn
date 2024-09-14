namespace CourseCatalog.Domain.Events;

public record class PrerequisiteRemovedEvent(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : IDomainEvent;
