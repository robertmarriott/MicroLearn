namespace CourseCatalog.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
