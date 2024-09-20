namespace CourseCatalog.Domain.Entities;

public class Instructor : Entity<InstructorId>
{
    public string UserName { get; }

    private Instructor(InstructorId id, string userName) : base(id)
    {
        UserName = userName;
    }

    public static Instructor Create(string userName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userName, nameof(userName));

        return new Instructor(InstructorId.CreateUnique(), userName);
    }
}
