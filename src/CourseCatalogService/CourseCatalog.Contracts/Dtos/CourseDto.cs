namespace CourseCatalog.Contracts.Dtos;

public record class CourseDto(
    Guid Id,
    Guid InstructorId,
    string Title,
    string SkillLevel,
    DateTime StartDate,
    DateTime EndDate,
    PriceDto Price,
    List<PrerequisiteDto> Prerequisites);
