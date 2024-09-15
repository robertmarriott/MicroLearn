namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CourseId.Create(value));

        builder.Property(c => c.InstructorId)
            .IsRequired();

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.SkillLevel)
            .IsRequired();

        builder.Property(c => c.StartDate)
            .IsRequired();

        builder.Property(c => c.EndDate)
            .IsRequired();

        builder.OwnsOne(c => c.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Amount)
                .IsRequired();

            priceBuilder.Property(p => p.Currency)
                .IsRequired();
        });

        builder.HasMany(c => c.Prerequisites)
            .WithOne()
            .HasForeignKey(p => p.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
