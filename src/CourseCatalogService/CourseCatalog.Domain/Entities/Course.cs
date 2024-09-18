namespace CourseCatalog.Domain.Entities;

public class Course : Entity<CourseId>
{
    public InstructorId InstructorId { get; }
    public string Title { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
    public Price Price { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime? CancellationDate { get; private set; } = null;
    public bool IsCancelled => CancellationDate is not null;
    public bool IsOpenForEnrollment => !IsCancelled && StartDate > DateTime.UtcNow;

    private readonly List<Prerequisite> _prerequisites = [];
    public IReadOnlyCollection<Prerequisite> Prerequisites =>
        _prerequisites.AsReadOnly();

    private Course(
        CourseId id,
        InstructorId instructorId,
        string title,
        SkillLevel skillLevel,
        Price price,
        DateTime startDate,
        DateTime endDate) : base(id)
    {
        InstructorId = instructorId;
        Title = title;
        SkillLevel = skillLevel;
        Price = price;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static Course Create(
        InstructorId instructorId,
        string title,
        SkillLevel skillLevel,
        Price price,
        DateTime startDate,
        DateTime endDate)
    {
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentOutOfRangeException
            .ThrowIfLessThan(
                startDate,
                DateTime.UtcNow,
                nameof(startDate));

        ArgumentOutOfRangeException
            .ThrowIfLessThan(endDate, startDate, nameof(endDate));

        var course = new Course(
            CourseId.CreateUnique(),
            instructorId,
            title,
            skillLevel,
            price,
            startDate,
            endDate);

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

    public void ChangePrice(Price newPrice)
    {
        Price = newPrice;
        AddDomainEvent(new CoursePriceChangedEvent(Id, Price));
    }

    public void ChangeStartDate(DateTime newStartDate)
    {
        ArgumentOutOfRangeException
            .ThrowIfLessThan(
                newStartDate,
                DateTime.UtcNow,
                nameof(newStartDate));

        StartDate = newStartDate;
        AddDomainEvent(new CourseStartDateChangedEvent(Id, StartDate));
    }

    public void ChangeEndDate(DateTime newEndDate)
    {
        ArgumentOutOfRangeException
            .ThrowIfLessThan(newEndDate, StartDate, nameof(newEndDate));

        EndDate = newEndDate;
        AddDomainEvent(new CourseEndDateChangedEvent(Id, EndDate));
    }

    public void Cancel()
    {
        if (IsCancelled)
        {
            throw new InvalidOperationException(
                "The course is already cancelled.");
        }

        if (StartDate <= DateTime.UtcNow)
        {
            throw new InvalidOperationException(
                "Cannot cancel a course that has already started.");
        }

        CancellationDate = DateTime.UtcNow;
        AddDomainEvent(new CourseCancelledEvent(Id, CancellationDate.Value));
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
