using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class PrerequisiteAddedEvent(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : IDomainEvent;
