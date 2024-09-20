namespace CourseCatalog.Infrastructure.Persistence.Repositories;

public class InstructorRepository(CatalogDbContext context)
    : IInstructorRepository
{
    public async Task<IReadOnlyList<Instructor>> GetAllAsync()
    {
        return await context.Instructors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Instructor?> GetByIdAsync(InstructorId instructorId)
    {
        return await context.Instructors
            .FirstOrDefaultAsync(instructor => instructor.Id == instructorId);
    }

    public async Task<bool> ExistsAsync(InstructorId instructorId)
    {
        return await context.Instructors
            .AnyAsync(instructor => instructor.Id == instructorId);
    }

    public async Task AddAsync(Instructor instructor)
    {
        await context.AddAsync(instructor);
    }
}
