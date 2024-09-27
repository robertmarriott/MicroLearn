using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CoursePriceChangedEvent(
    CourseId CourseId,
    Price NewPrice) : DomainEvent;
