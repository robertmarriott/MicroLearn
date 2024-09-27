using CourseCatalog.Domain.Common.Models;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseEndDateChangedEvent(
    CourseId CourseId,
    DateTime NewEndDate) : DomainEvent;
