namespace CourseCatalog.Contracts.Responses;

public record class CourseResponse(
    Guid Id,
    Guid InstructorId,
    string Title,
    string SkillLevel,
    PriceDto Price,
    DateTime StartDate,
    DateTime EndDate,
    DateTime? CancellationDate,
    bool IsCancelled,
    bool IsOpenForEnrollment,
    IReadOnlyList<PrerequisiteResponse> Prerequisites);
