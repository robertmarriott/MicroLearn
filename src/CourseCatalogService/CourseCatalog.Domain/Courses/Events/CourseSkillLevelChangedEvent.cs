using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.Enums;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseSkillLevelChangedEvent(
    CourseId CourseId,
    SkillLevel NewSkillLevel) : DomainEvent;
