namespace CourseCatalog.Contracts.Responses;

public record class PrerequisiteResponse(
    Guid Id,
    Guid CourseId,
    string Description);
