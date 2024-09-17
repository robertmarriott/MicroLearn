namespace CourseCatalog.Contracts.Dtos;

public record class PrerequisiteDto(Guid Id, Guid CourseId, string Description);
