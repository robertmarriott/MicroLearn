using CourseCatalog.Contracts.Courses.Dtos;

namespace CourseCatalog.Contracts.Courses.Responses;

public record class CourseResponse(
    Guid Id,
    Guid InstructorId,
    string Title,
    string SkillLevel,
    PriceDto Price,
    bool IsFree,
    DateTime StartDate,
    DateTime EndDate,
    DateTime? CancellationDate,
    bool IsCancelled,
    bool IsOpenForEnrollment,
    IReadOnlyList<PrerequisiteResponse> Prerequisites);
