using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses.Entities;

public class CourseModule : Entity<CourseModuleId>
{
    public CourseId CourseId { get; private init; }
    public short ModuleNumber { get; private set; }
    public string Title { get; private set; }
    public string Summary { get; private set; }

    private CourseModule(
        CourseModuleId id,
        CourseId courseId,
        short moduleNumber,
        string title,
        string summary) : base(id)
    {
        CourseId = courseId;
        ModuleNumber = moduleNumber;
        Title = title;
        Summary = summary;
    }

    public static CourseModule Create(
        CourseId courseId,
        short moduleNumber,
        string title,
        string summary)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(
            moduleNumber, nameof(moduleNumber));

        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentNullException.ThrowIfNullOrEmpty(summary, nameof(summary));

        return new CourseModule(
            new CourseModuleId(Guid.NewGuid()),
            courseId,
            moduleNumber,
            title,
            summary);
    }
}
