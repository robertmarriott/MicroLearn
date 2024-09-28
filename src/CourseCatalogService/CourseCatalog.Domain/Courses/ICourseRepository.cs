using CourseCatalog.Domain.Courses.ValueObjects;
using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Domain.Courses;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> GetAllAsync(int pageNumber, int pageSize);
    Task<IReadOnlyList<Course>> GetByInstructorIdAsync(
        InstructorId instructorId);
    Task<Course?> GetByIdAsync(CourseId courseId);
    Task<bool> ExistsAsync(CourseId courseId);
    Task<int> CountAsync();
    Task AddAsync(Course course);
}
