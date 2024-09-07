namespace CourseCatalog.Application.Commands;

public record class AddModuleCommand(
    CourseId CourseId, short ModuleNumber, string Title, string Summary)
    : IRequest;
