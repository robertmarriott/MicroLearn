namespace CourseCatalog.Domain.Entities;

public class Instructor : Entity<InstructorId>
{
    public string Name { get; }

    private Instructor(InstructorId id, string name) : base(id)
    {
        Name = name;
    }

    public static Instructor Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        return new Instructor(InstructorId.CreateUnique(), name);
    }
}
