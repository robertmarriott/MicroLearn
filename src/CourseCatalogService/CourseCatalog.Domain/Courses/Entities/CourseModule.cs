using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses.Entities;

public class CourseModule : Entity<CourseModuleId>
{
    public short ModuleNumber { get; private set; }
    public string Title { get; private set; } = null!;
    public string Summary { get; private set; } = null!;

    private CourseModule() { }

    private CourseModule(
        CourseModuleId id, short moduleNumber, string title, string summary)
        : base(id)
    {
        ModuleNumber = moduleNumber;
        Title = title;
        Summary = summary;
    }

    public static CourseModule Create(
        short moduleNumber, string title, string summary)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(
            moduleNumber, nameof(moduleNumber));
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));
        ArgumentNullException.ThrowIfNullOrEmpty(summary, nameof(summary));

        return new CourseModule(
            new CourseModuleId(Guid.NewGuid()), moduleNumber, title, summary);
    }
}
