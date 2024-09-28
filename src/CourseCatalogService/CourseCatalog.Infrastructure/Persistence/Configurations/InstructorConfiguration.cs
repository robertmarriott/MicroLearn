using CourseCatalog.Domain.Instructors;
using CourseCatalog.Domain.Instructors.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(instructor => instructor.Id);

        builder.Property(instructor => instructor.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => InstructorId.Create(value));

        builder.Property(instructor => instructor.UserName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Ignore(Instructor => Instructor.DomainEvents);
    }
}
