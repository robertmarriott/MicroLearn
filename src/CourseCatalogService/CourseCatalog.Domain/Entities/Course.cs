namespace CourseCatalog.Domain.Entities;

public class Course : AggregateRoot<CourseId>
{
    public InstructorId InstructorId { get; }
    public string Title { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }

    private readonly List<Prerequisite> _prerequisites = [];
    public IReadOnlyCollection<Prerequisite> Prerequisites =>
        _prerequisites.AsReadOnly();

    private Course(
        CourseId id,
        InstructorId instructorId,
        string title,
        SkillLevel skillLevel,
        DateOnly startDate,
        DateOnly endDate) : base(id)
    {
        InstructorId = instructorId;
        Title = title;
        SkillLevel = skillLevel;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static Course Create(
        InstructorId instructorId,
        string title,
        SkillLevel skillLevel,
        DateOnly startDate,
        DateOnly endDate)
    {
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentOutOfRangeException.ThrowIfLessThan(
            startDate,
            DateOnly.FromDateTime(DateTime.UtcNow),
            nameof(startDate));

        ArgumentOutOfRangeException.ThrowIfLessThan(
            endDate, startDate, nameof(endDate));

        var course = new Course(
            new CourseId(),
            instructorId,
            title,
            skillLevel,
            startDate,
            endDate);

        course.RaiseDomainEvent(
            new CourseCreatedEvent(course.InstructorId, course.Id));

        return course;
    }

    public void ChangeTitle(string newTitle)
    {
        ArgumentException.ThrowIfNullOrEmpty(newTitle, nameof(newTitle));

        Title = newTitle;

        RaiseDomainEvent(new CourseTitleChangedEvent(Id, Title));
    }

    public void ChangeSkillLevel(SkillLevel newSkillLevel)
    {
        SkillLevel = newSkillLevel;

        RaiseDomainEvent(new CourseSkillLevelChangedEvent(Id, SkillLevel));
    }

    public void ChangeStartDate(DateOnly newStartDate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(
            newStartDate,
            DateOnly.FromDateTime(DateTime.UtcNow),
            nameof(newStartDate));

        StartDate = newStartDate;

        RaiseDomainEvent(new CourseStartDateChangedEvent(Id, StartDate));
    }

    public void ChangeEndDate(DateOnly newEndDate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(
            newEndDate, StartDate, nameof(newEndDate));

        EndDate = newEndDate;

        RaiseDomainEvent(new CourseEndDateChangedEvent(Id, EndDate));
    }

    public PrerequisiteId AddPrerequisite(string description)
    {
        var prerequisite = Prerequisite.Create(Id, description);
        _prerequisites.Add(prerequisite);

        RaiseDomainEvent(new PrerequisiteAddedEvent(Id, prerequisite.Id));

        return prerequisite.Id;
    }

    public void RemovePrerequisite(PrerequisiteId prerequisiteId)
    {
        var prerequisite = _prerequisites
            .FirstOrDefault(p => p.Id == prerequisiteId)
            ?? throw new PrerequisiteNotFoundException(prerequisiteId);

        _prerequisites.Remove(prerequisite);

        RaiseDomainEvent(new PrerequisiteRemovedEvent(Id, prerequisite.Id));
    }
}
