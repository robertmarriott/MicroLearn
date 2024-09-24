namespace CourseCatalog.Domain.Repositories;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync(int pageIndex, int pageSize);

    Task<IReadOnlyList<Course>> GetByInstructorIdAsync(
        InstructorId instructorId);

    Task<Course?> GetByIdAsync(CourseId courseId);

    Task<bool> ExistsAsync(CourseId courseId);

    Task<int> CountAsync();

    Task AddAsync(Course course);
}
