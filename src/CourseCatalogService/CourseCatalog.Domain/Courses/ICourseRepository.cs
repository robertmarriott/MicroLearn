namespace CourseCatalog.Domain.Courses;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync(int pageNumber, int pageSize);
    Task<Course?> GetByIdAsync(CourseId id);
    Task AddAsync(Course course);
    Task UpdateAsync(Course course);
    Task DeleteAsync(CourseId id);
}
