namespace CourseCatalog.Contracts.Requests;

public record class CreateCourseRequest(
    Guid InstructorId,
    string Title,
    string SkillLevel,
    PriceDto Price,
    DateTime StartDate,
    DateTime EndDate);
