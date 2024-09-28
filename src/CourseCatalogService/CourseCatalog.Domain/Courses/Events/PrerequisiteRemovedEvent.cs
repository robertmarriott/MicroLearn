using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class PrerequisiteRemovedEvent(
    CourseId CourseId,
    PrerequisiteId PrerequisiteId) : IDomainEvent;
