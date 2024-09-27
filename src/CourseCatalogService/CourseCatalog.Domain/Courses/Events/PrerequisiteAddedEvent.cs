using CourseCatalog.Domain.Common.Models;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class PrerequisiteAddedEvent(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : DomainEvent;
