namespace CourseCatalog.Domain.Aggregates;

public class Course : AggregateRoot<CourseId>
{
    public InstructorId InstructorId { get; }
    public string Title { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public Price Price { get; private set; }

    private readonly List<Prerequisite> _prerequisites = [];
    public IReadOnlyCollection<Prerequisite> Prerequisites =>
        _prerequisites.AsReadOnly();

    private Course(
        CourseId id,
        InstructorId instructorId,
        string title,
        SkillLevel skillLevel,
        DateOnly startDate,
        DateOnly endDate,
        Price price) : base(id)
    {
        InstructorId = instructorId;
        Title = title;
        SkillLevel = skillLevel;
        StartDate = startDate;
        EndDate = endDate;
        Price = price;
    }

    public static Course Create(
        InstructorId instructorId,
        string title,
        SkillLevel skillLevel,
        DateOnly startDate,
        DateOnly endDate,
        Price price)
    {
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentOutOfRangeException
            .ThrowIfLessThan(
                startDate,
                DateOnly.FromDateTime(DateTime.UtcNow),
                nameof(startDate));

        ArgumentOutOfRangeException
            .ThrowIfLessThan(endDate, startDate, nameof(endDate));

        var course = new Course(
            CourseId.CreateUnique(),
            instructorId,
            title,
            skillLevel,
            startDate,
            endDate,
            price);

        course.AddDomainEvent(
            new CourseCreatedEvent(course.InstructorId, course.Id));

        return course;
    }

    public void ChangeTitle(string newTitle)
    {
        ArgumentException.ThrowIfNullOrEmpty(newTitle, nameof(newTitle));
        Title = newTitle;
        AddDomainEvent(new CourseTitleChangedEvent(Id, Title));
    }

    public void ChangeSkillLevel(SkillLevel newSkillLevel)
    {
        SkillLevel = newSkillLevel;
        AddDomainEvent(new CourseSkillLevelChangedEvent(Id, SkillLevel));
    }

    public void ChangeStartDate(DateOnly newStartDate)
    {
        ArgumentOutOfRangeException
            .ThrowIfLessThan(
                newStartDate,
                DateOnly.FromDateTime(DateTime.UtcNow),
                nameof(newStartDate));

        StartDate = newStartDate;
        AddDomainEvent(new CourseStartDateChangedEvent(Id, StartDate));
    }

    public void ChangeEndDate(DateOnly newEndDate)
    {
        ArgumentOutOfRangeException
            .ThrowIfLessThan(newEndDate, StartDate, nameof(newEndDate));

        EndDate = newEndDate;
        AddDomainEvent(new CourseEndDateChangedEvent(Id, EndDate));
    }

    public void ChangePrice(Price newPrice)
    {
        Price = newPrice;
        AddDomainEvent(new CoursePriceChangedEvent(Id, Price));
    }

    public PrerequisiteId AddPrerequisite(string description)
    {
        var prerequisite = Prerequisite.Create(Id, description);
        _prerequisites.Add(prerequisite);
        AddDomainEvent(new PrerequisiteAddedEvent(Id, prerequisite.Id));

        return prerequisite.Id;
    }

    public void RemovePrerequisite(PrerequisiteId prerequisiteId)
    {
        var prerequisite = _prerequisites
            .FirstOrDefault(p => p.Id == prerequisiteId)
            ?? throw new PrerequisiteNotFoundException(prerequisiteId);

        _prerequisites.Remove(prerequisite);
        AddDomainEvent(new PrerequisiteRemovedEvent(Id, prerequisite.Id));
    }
}
