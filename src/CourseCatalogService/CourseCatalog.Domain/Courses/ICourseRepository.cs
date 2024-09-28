using Ardalis.Specification;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses;

public interface ICourseRepository
{
    Task<IReadOnlyList<Course>> ListAsync(
        ISpecification<Course> specification, int pageNumber, int pageSize);
    Task<Course?> GetByIdAsync(CourseId courseId);
    Task<bool> ExistsAsync(CourseId courseId);
    Task<int> CountAsync(ISpecification<Course> specification);
    Task AddAsync(Course course);
}
