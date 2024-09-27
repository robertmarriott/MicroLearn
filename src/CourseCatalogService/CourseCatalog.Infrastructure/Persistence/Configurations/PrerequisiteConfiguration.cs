using CourseCatalog.Domain.Courses.Entities;
using CourseCatalog.Domain.Courses.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseCatalog.Infrastructure.Persistence.Configurations;

public class PrerequisiteConfiguration : IEntityTypeConfiguration<Prerequisite>
{
    public void Configure(EntityTypeBuilder<Prerequisite> builder)
    {
        builder.HasKey(prerequisite => prerequisite.Id);

        builder.Property(prerequisite => prerequisite.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => PrerequisiteId.Create(value));

        builder.Property(prerequisite => prerequisite.CourseId).IsRequired();

        builder.Property(prerequisite => prerequisite.Description)
            .IsRequired()
            .HasMaxLength(500);
    }
}
