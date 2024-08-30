using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses.Entities;

public class Prerequisite : Entity<PrerequisiteId>
{
    public string Description { get; private set; } = null!;

    private Prerequisite(PrerequisiteId id, string description) : base(id)
    {
        Description = description;
    }

    public static Prerequisite Create(string description)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(
            description, nameof(description));

        return new Prerequisite(
            new PrerequisiteId(Guid.NewGuid()), description);
    }
}
