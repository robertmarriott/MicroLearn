﻿namespace CourseCatalog.Domain.Entities;

public class Course : AggregateRoot<CourseId>
{
    public InstructorId InstructorId { get; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public SkillLevel SkillLevel { get; private set; }
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
        SkillLevel skillLevel,
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
        SkillLevel skillLevel,
        DateOnly startDate,
        DateOnly endDate)
    {
        ArgumentException.ThrowIfNullOrEmpty(title, nameof(title));

        ArgumentException.ThrowIfNullOrEmpty(
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
            skillLevel,
            startDate,
            endDate);
    }

    public void ChangeTitle(string newTitle)
    {
        ArgumentException.ThrowIfNullOrEmpty(newTitle, nameof(newTitle));

        Title = newTitle;
    }

    public void ChangeDescription(string newDescription)
    {
        ArgumentException.ThrowIfNullOrEmpty(
            newDescription, nameof(newDescription));

        Description = newDescription;
    }

    public void ChangeSkillLevel(SkillLevel skillLevel)
    {
        SkillLevel = skillLevel;
    }

    public void ChangeStartDate(DateOnly newStartDate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(
            newStartDate,
            DateOnly.FromDateTime(DateTime.UtcNow),
            nameof(newStartDate));

        StartDate = newStartDate;
    }

    public void ChangeEndDate(DateOnly newEndDate)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(
            newEndDate, StartDate, nameof(newEndDate));

        EndDate = newEndDate;
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
