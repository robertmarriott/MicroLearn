using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CourseCatalog.Domain.Courses;
using CourseCatalog.Domain.Courses.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalog.Infrastructure.Persistence.Repositories;

public class CourseRepository(CatalogDbContext context) : ICourseRepository
{
    public async Task<IReadOnlyList<Course>> ListAsync(
        ISpecification<Course> specification, int pageNumber, int pageSize)
    {
        return await context.Courses
            .WithSpecification(specification)
            .Include(course => course.Prerequisites)
            .OrderByDescending(course => course.StartDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(CourseId courseId)
    {
        return await context.Courses
            .Where(course => course.Id == courseId)
            .Include(course => course.Prerequisites)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> ExistsAsync(CourseId courseId)
    {
        return await context.Courses.AnyAsync(course => course.Id == courseId);
    }

    public async Task<int> CountAsync(ISpecification<Course> specification)
    {
        return await context.Courses
            .WithSpecification(specification)
            .CountAsync();
    }

    public async Task AddAsync(Course course)
    {
        await context.Courses.AddAsync(course);
    }
}
