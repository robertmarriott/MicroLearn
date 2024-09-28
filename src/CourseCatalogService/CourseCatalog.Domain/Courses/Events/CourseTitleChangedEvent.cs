using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseTitleChangedEvent(
    CourseId CourseId,
    string NewTitle) : IDomainEvent;
