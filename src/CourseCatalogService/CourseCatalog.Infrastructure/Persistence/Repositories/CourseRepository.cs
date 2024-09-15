namespace CourseCatalog.Infrastructure.Persistence.Repositories;

public class CourseRepository(CatalogDbContext context) : ICourseRepository
{
    public async Task<List<Course>> GetAllAsync()
    {
        return await context.Courses.ToListAsync();
    }

    public async Task<List<Course>> GetAllOpenForEnrollmentAsync()
    {
        var currentDate = DateTime.Now;

        return await context.Courses
            .Where(course => course.StartDate >= currentDate)
            .ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(CourseId courseId)
    {
        return await context.Courses
            .FirstOrDefaultAsync(course => course.Id == courseId);
    }

    public async Task AddAsync(Course course)
    {
        await context.Courses.AddAsync(course);
    }
}
