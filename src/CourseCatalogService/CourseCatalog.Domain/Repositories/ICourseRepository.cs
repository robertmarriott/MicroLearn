namespace CourseCatalog.Domain.Repositories;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync();
    Task<IReadOnlyList<Course>> GetByInstructorIdAsync(InstructorId instructorId);
    Task<Course?> GetByIdAsync(CourseId courseId);
    Task AddAsync(Course course);
}
