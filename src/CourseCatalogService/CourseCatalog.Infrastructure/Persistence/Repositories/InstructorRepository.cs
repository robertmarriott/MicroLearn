using CourseCatalog.Domain.Instructors;
using CourseCatalog.Domain.Instructors.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CourseCatalog.Infrastructure.Persistence.Repositories;

public class InstructorRepository(CatalogDbContext context)
    : IInstructorRepository
{
    public async Task<IReadOnlyList<Instructor>> GetAllAsync(
        int pageNumber, int pageSize)
    {
        return await context.Instructors
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
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

    public async Task<int> CountAsync()
    {
        return await context.Instructors.CountAsync();
    }

    public async Task AddAsync(Instructor instructor)
    {
        await context.AddAsync(instructor);
    }
}
