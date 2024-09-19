namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(instructor => instructor.Id);

        builder.Property(instructor => instructor.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => InstructorId.Create(value));

        builder.Property(instructor => instructor.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
