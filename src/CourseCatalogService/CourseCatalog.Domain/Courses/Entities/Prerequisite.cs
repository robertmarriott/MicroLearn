using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Entities;

public class Prerequisite : Entity<PrerequisiteId>
{
    public CourseId CourseId { get; }
    public string Description { get; }

    private Prerequisite(
        PrerequisiteId id,
        CourseId courseId,
        string description) : base(id)
    {
        CourseId = courseId;
        Description = description;
    }

    public static Prerequisite Create(CourseId courseId, string description)
    {
        ArgumentException.ThrowIfNullOrEmpty(description, nameof(description));

        return new Prerequisite(
            PrerequisiteId.CreateUnique(),
            courseId,
            description);
    }
}
