using CourseCatalog.Domain.Common;
using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Domain.Instructors.Entities;

public class Instructor : AggregateRoot<InstructorId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";

    private Instructor(InstructorId id, string firstName, string lastName)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Instructor Create(string firstName, string lastName)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(
            firstName, nameof(firstName));

        ArgumentNullException.ThrowIfNullOrWhiteSpace(
            lastName, nameof(lastName));

        return new Instructor(new InstructorId(), firstName, lastName);
    }
}
