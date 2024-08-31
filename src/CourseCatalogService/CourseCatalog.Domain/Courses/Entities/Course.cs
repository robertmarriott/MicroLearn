using CourseCatalog.Domain.Common;
using CourseCatalog.Domain.Instructors.Entities;

namespace CourseCatalog.Domain.Courses.Entities;

public class Course : AggregateRoot<CourseId>
{
    public InstructorId InstructorId { get; private init; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }

    private readonly List<Prerequisite> _prerequisites = [];
    public IReadOnlyCollection<Prerequisite> Prerequisites =>
        _prerequisites.AsReadOnly();

    private readonly List<CourseModule> _modules = [];
    public IReadOnlyCollection<CourseModule> Modules =>
        _modules.AsReadOnly();

    private Course(
        CourseId id,
        InstructorId instructorId,
        string title,
        string description,
        DateOnly startDate,
        DateOnly endDate) : base(id)
    {
        InstructorId = instructorId;
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static Course Create(
        InstructorId instructorId,
        string title,
        string description,
        DateOnly startDate,
        DateOnly endDate)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentNullException.ThrowIfNullOrEmpty(
            description, nameof(description));

        ArgumentOutOfRangeException.ThrowIfLessThan(
            startDate,
            DateOnly.FromDateTime(DateTime.UtcNow),
            nameof(startDate));

        ArgumentOutOfRangeException.ThrowIfLessThan(
            endDate, startDate, nameof(endDate));

        return new Course(
            new CourseId(Guid.NewGuid()),
            instructorId,
            title,
            description,
            startDate,
            endDate);
    }

    public void AddModule(CourseModule module)
    {
        _modules.Add(module);
    }

    public void RemoveModule(CourseModule module)
    {
        _modules.Remove(module);
    }

    public void AddPrerequisite(Prerequisite prerequisite)
    {
        _prerequisites.Add(prerequisite);
    }

    public void RemovePrerequisite(Prerequisite prerequisite)
    {
        _prerequisites.Remove(prerequisite);
    }
}
