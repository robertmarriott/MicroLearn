namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(course => course.Id);

        builder.Property(course => course.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => CourseId.Create(value));

        builder.Property(course => course.InstructorId).IsRequired();

        builder.Property(course => course.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(course => course.SkillLevel).IsRequired();

        builder.OwnsOne(course => course.Price, priceBuilder =>
        {
            priceBuilder.Property(price => price.Amount).IsRequired();

            priceBuilder.Property(price => price.Currency).IsRequired();
        });

        builder.Property(course => course.StartDate).IsRequired();

        builder.Property(course => course.EndDate).IsRequired();

        builder.Ignore(course => course.IsCancelled);

        builder.Ignore(course => course.IsOpenForEnrollment);

        builder.HasMany(course => course.Prerequisites)
            .WithOne()
            .HasForeignKey(prerequisite => prerequisite.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
