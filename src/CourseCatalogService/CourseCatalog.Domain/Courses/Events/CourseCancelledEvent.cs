using CourseCatalog.Domain.Common.Models;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseCancelledEvent(
    CourseId CourseId,
    DateTime CancellationDate) : DomainEvent;
