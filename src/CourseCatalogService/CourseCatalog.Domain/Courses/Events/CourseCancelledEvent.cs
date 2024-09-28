using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseCancelledEvent(
    CourseId CourseId,
    DateTime CancellationDate) : IDomainEvent;
