namespace CourseCatalog.Infrastructure.Persistence.Repositories;

public class CourseRepository(CatalogDbContext context) : ICourseRepository
{
    public async Task<List<Course>> GetAllAsync()
    {
        return await context.Courses
            .Include(course => course.Prerequisites)
            .OrderByDescending(course => course.StartDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Course>> GetOpenForEnrollmentAsync()
    {
        var currentDate = DateTime.Now;

        return await context.Courses
            .Where(course => course.IsOpenForEnrollment)
            .Include(course => course.Prerequisites)
            .OrderByDescending(course => course.StartDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Course>> GetByInstructorIdAsync(
        InstructorId instructorId)
    {
        return await context.Courses
            .Where(course => course.InstructorId == instructorId)
            .Include(course => course.Prerequisites)
            .OrderByDescending(course => course.StartDate)
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

    public async Task AddAsync(Course course)
    {
        await context.Courses.AddAsync(course);
    }
}
