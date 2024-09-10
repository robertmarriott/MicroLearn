namespace CourseCatalog.Domain.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<IEnumerable<Course>> GetAllOpenForEnrollmentAsync();
    Task<Course?> GetByIdAsync(CourseId id);
    Task AddAsync(Course course);
    Task DeleteAsync(Course course);
}
