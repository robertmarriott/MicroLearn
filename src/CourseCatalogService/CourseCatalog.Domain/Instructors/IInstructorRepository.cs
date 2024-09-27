using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Domain.Instructors;

public interface IInstructorRepository
{
    Task<IReadOnlyList<Instructor>> GetAllAsync(int pageNumber, int pageSize);

    Task<Instructor?> GetByIdAsync(InstructorId instructorId);

    Task<bool> ExistsAsync(InstructorId instructorId);

    Task<int> CountAsync();

    Task AddAsync(Instructor instructor);
}
