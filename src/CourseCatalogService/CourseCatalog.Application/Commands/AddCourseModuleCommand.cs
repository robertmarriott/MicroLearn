namespace CourseCatalog.Application.Commands;

public record class AddCourseModuleCommand(
    CourseId CourseId,
    short ModuleNumber,
    string Title,
    string Summary) : IRequest;
