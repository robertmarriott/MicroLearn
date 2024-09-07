namespace CourseCatalog.Application.Commands;

public record class RemoveModuleCommand(
    CourseId CourseId, ModuleId ModuleId) : IRequest;
