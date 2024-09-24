namespace CourseCatalog.Domain.Repositories;

public interface IInstructorRepository
{
    Task<IReadOnlyList<Instructor>> GetAllAsync(int pageIndex, int pageSize);

    Task<Instructor?> GetByIdAsync(InstructorId instructorId);

    Task<bool> ExistsAsync(InstructorId instructorId);

    Task<int> CountAsync();

    Task AddAsync(Instructor instructor);
}
