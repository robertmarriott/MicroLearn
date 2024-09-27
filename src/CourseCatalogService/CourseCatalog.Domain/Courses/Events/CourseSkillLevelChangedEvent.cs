using CourseCatalog.Domain.Common.Models;
using CourseCatalog.Domain.Courses.Enums;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseSkillLevelChangedEvent(
    CourseId CourseId,
    SkillLevel NewSkillLevel) : DomainEvent;
