namespace CourseCatalog.Domain.Events;

public record class CourseEndDateChangedEvent(
    CourseId CourseId,
    DateTime NewEndDate) : IDomainEvent;
