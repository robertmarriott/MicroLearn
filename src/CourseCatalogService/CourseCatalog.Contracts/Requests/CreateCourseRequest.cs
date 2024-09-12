namespace CourseCatalog.Contracts.Requests;

public record class CreateCourseRequest(
    Guid InstructorId,
    string Title,
    string SkillLevel,
    DateOnly StartDate,
    DateOnly EndDate,
    PriceDto Price);
