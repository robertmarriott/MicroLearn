namespace CourseCatalog.Contracts.Responses;

public record class GetAllCoursesResponse(
    IReadOnlyList<CourseResponse> Courses);
