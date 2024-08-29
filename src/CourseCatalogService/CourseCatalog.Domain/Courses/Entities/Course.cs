using CourseCatalog.Domain.Common;

namespace CourseCatalog.Domain.Courses.Entities;

public class Course : Entity, IAggregateRoot
{
    public Guid InstructorId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Syllabus { get; private set; } = null!;
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }

    private readonly List<CourseModule> _modules = [];
    public IReadOnlyCollection<CourseModule> Modules => _modules.AsReadOnly();

    private Course() { }

    private Course(
        string title,
        string syllabus,
        DateOnly startDate,
        DateOnly endDate) : this()
    {
        Title = title;
        Syllabus = syllabus;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static Course Create(
        string title,
        string syllabus,
        DateOnly startDate,
        DateOnly endDate)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));
        ArgumentNullException.ThrowIfNullOrEmpty(syllabus, nameof(syllabus));
        ArgumentOutOfRangeException.ThrowIfLessThan(
            startDate,
            DateOnly.FromDateTime(DateTime.UtcNow),
            nameof(startDate));
        ArgumentOutOfRangeException.ThrowIfLessThan(
            endDate,
            startDate,
            nameof(endDate));

        return new(title, syllabus, startDate, endDate);
    }

    public void AddModule(CourseModule module)
    {
        _modules.Add(module);
    }

    public void RemoveModule(CourseModule module)
    {
        _modules.Remove(module);
    }
}
