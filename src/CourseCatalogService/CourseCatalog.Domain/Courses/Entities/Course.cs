using CourseCatalog.Domain.Common;
using CourseCatalog.Domain.Courses.ValueObjects;
using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Domain.Courses.Entities;

public class Course : AggregateRoot<CourseId>
{
    public InstructorId InstructorId { get; }
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
            new CourseId(),
            instructorId,
            title,
            description,
            startDate,
            endDate);
    }

    public void UpdateTitle(string title)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(title, nameof(title));

        Title = title;
    }

    public void UpdateDescription(string description)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(
            description, nameof(description));

        Description = description;
    }

    public void UpdateStartDate(DateOnly startDate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(
            startDate,
            DateOnly.FromDateTime(DateTime.UtcNow),
            nameof(startDate));

        StartDate = startDate;
    }

    public void UpdateEndDate(DateOnly endDate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(
            endDate, StartDate, nameof(endDate));

        EndDate = endDate;
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
