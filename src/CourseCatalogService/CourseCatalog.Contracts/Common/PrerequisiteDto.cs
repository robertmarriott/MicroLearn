namespace CourseCatalog.Contracts.Common;

public record class PrerequisiteDto(Guid Id, Guid CourseId, string Description);
