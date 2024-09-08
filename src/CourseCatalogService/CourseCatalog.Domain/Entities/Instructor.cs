namespace CourseCatalog.Domain.Entities;

public class Instructor : AggregateRoot<InstructorId>
{
    public string FirstName { get; }
    public string LastName { get; }

    private Instructor(InstructorId id, string firstName, string lastName)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Instructor Create(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            firstName, nameof(firstName));

        ArgumentException.ThrowIfNullOrWhiteSpace(
            lastName, nameof(lastName));

        return new Instructor(new InstructorId(), firstName, lastName);
    }
}
