namespace CourseCatalog.Domain.Repositories;

public interface IInstructorRepository
{
    Task<IReadOnlyList<Instructor>> GetAllAsync();
    Task<Instructor?> GetByIdAsync(InstructorId instructorId);
    Task<bool> ExistsAsync(InstructorId instructorId);
    Task AddAsync(Instructor instructor);
}
