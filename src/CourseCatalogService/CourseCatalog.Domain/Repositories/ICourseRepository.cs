namespace CourseCatalog.Domain.Repositories;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<List<Course>> GetAllOpenForEnrollmentAsync();
    Task<Course?> GetByIdAsync(CourseId courseId);
    Task AddAsync(Course course);
}
