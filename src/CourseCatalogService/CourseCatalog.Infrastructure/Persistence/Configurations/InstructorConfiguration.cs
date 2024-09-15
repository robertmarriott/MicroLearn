namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => InstructorId.Create(value));

        builder.Property(i => i.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(i => i.LastName)
            .IsRequired()
            .HasMaxLength(50);
    }
}
