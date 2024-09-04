using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses;

public class Prerequisite : Entity<PrerequisiteId>
{
    public CourseId CourseId { get; }
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

        return new Prerequisite(new PrerequisiteId(), courseId, description);
    }

    public void ChangeDescription(string newDescription)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(
            newDescription, nameof(newDescription));

        Description = newDescription;
    }
}
