namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(instructor => instructor.Id);

        builder.Property(instructor => instructor.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => InstructorId.Create(value));

        builder.Property(instructor => instructor.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(instructor => instructor.LastName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
