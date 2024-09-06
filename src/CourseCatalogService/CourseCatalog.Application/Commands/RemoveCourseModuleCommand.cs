namespace CourseCatalog.Application.Commands;

public record class RemoveCourseModuleCommand(
    CourseId CourseId, CourseModuleId CourseModuleId) : IRequest;
