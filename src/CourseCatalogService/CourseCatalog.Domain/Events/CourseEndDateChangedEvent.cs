namespace CourseCatalog.Domain.Events;

public record class CourseEndDateChangedEvent(
    CourseId CourseId,
    DateOnly NewEndDate) : IDomainEvent;
