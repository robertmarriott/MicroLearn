using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses.Entities;

public class CourseModule : Entity
{
    public short ModuleNumber { get; private set; }
    public string Title { get; private set; } = null!;
    public string Summary { get; private set; } = null!;

    private CourseModule() { }

    private CourseModule(short moduleNumber, string title, string summary)
    {
        ModuleNumber = moduleNumber;
        Title = title;
        Summary = summary;
    }

    public static CourseModule Create(
        short moduleNumber,
        string title,
        string summary)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(
            moduleNumber,
            nameof(moduleNumber));
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));
        ArgumentNullException.ThrowIfNullOrEmpty(summary, nameof(summary));

        return new CourseModule(moduleNumber, title, summary);
    }
}
