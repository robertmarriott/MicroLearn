namespace CourseCatalog.Application.Dtos;

public record class CourseDto(
    Guid CourseId,
    Guid InstructorId,
    string Title,
    string SkillLevel,
    DateTime StartDate,
    DateTime EndDate,
    PriceDto Price,
    IEnumerable<PrerequisiteDto> Prerequisites);
