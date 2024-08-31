using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses.Entities;

public class Prerequisite : Entity<PrerequisiteId>
{
    public CourseId CourseId { get; private init; }
    public string Description { get; private set; }

    private Prerequisite(
        PrerequisiteId id, CourseId courseId, string description) : base(id)
    {
        CourseId = courseId;
        Description = description;
    }

    public static Prerequisite Create(CourseId courseId, string description)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(
            description, nameof(description));

        return new Prerequisite(
            new PrerequisiteId(Guid.NewGuid()), courseId, description);
    }
}
