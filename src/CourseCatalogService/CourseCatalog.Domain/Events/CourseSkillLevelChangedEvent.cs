namespace CourseCatalog.Domain.Events;

public record class CourseSkillLevelChangedEvent(
    CourseId CourseId,
    SkillLevel NewSkillLevel) : IDomainEvent;
