namespace CourseCatalog.Contracts.Dtos;

public record class CourseDto(
    Guid Id,
    Guid InstructorId,
    string Title,
    string SkillLevel,
    PriceDto Price,
    DateTime StartDate,
    DateTime EndDate,
    DateTime? CancellationDate,
    List<PrerequisiteDto> Prerequisites);
