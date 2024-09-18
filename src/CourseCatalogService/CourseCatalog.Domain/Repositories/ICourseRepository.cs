namespace CourseCatalog.Domain.Repositories;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<List<Course>> GetOpenForEnrollmentAsync();
    Task<List<Course>> GetByInstructorIdAsync(InstructorId instructorId);
    Task<Course?> GetByIdAsync(CourseId courseId);
    Task AddAsync(Course course);
}
