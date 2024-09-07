namespace CourseCatalog.Domain.Events;

public record class CourseCreatedEvent(
    InstructorId InstructorId, CourseId CourseId) : IDomainEvent;
