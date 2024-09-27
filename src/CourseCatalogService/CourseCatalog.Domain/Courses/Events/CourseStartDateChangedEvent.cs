using CourseCatalog.Domain.Common.Models;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseStartDateChangedEvent(
    CourseId CourseId,
    DateTime NewStartDate) : DomainEvent;
