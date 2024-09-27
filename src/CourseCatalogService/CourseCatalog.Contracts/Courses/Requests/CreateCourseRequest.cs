using CourseCatalog.Contracts.Courses.Dtos;

namespace CourseCatalog.Contracts.Courses.Requests;

public record class CreateCourseRequest(
    Guid InstructorId,
    string Title,
    string SkillLevel,
    PriceDto Price,
    DateTime StartDate,
    DateTime EndDate);
