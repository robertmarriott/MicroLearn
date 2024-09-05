namespace CourseCatalog.Domain.Entities;

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

        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentException.ThrowIfNullOrEmpty(summary, nameof(summary));

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
        ArgumentException.ThrowIfNullOrEmpty(newTitle, nameof(newTitle));

        Title = newTitle;
    }

    public void ChangeSummary(string newSummary)
    {
        ArgumentException.ThrowIfNullOrEmpty(
            newSummary, nameof(newSummary));

        Summary = newSummary;
    }
}
