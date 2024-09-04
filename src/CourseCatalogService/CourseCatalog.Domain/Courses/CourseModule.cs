using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses;

public class CourseModule : Entity<CourseModuleId>
{
    public CourseId CourseId { get; }
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
        CourseId courseId, short moduleNumber, string title, string summary)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(
            moduleNumber, nameof(moduleNumber));

        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentNullException.ThrowIfNullOrEmpty(summary, nameof(summary));

        return new CourseModule(
            new CourseModuleId(), courseId, moduleNumber, title, summary);
    }

    public void ChangeModuleNumber(short newModuleNumber)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(
            newModuleNumber, nameof(newModuleNumber));

        ModuleNumber = newModuleNumber;
    }

    public void ChangeTitle(string newTitle)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(newTitle, nameof(newTitle));

        Title = newTitle;
    }

    public void ChangeSummary(string newSummary)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(
            newSummary, nameof(newSummary));

        Summary = newSummary;
    }
}
