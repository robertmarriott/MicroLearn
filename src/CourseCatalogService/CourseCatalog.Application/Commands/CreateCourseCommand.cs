namespace CourseCatalog.Application.Commands;

public record class CreateCourseCommand(
    InstructorId InstructorId,
    string Title,
    string Description,
    SkillLevel SkillLevel,
    DateOnly StartDate,
    DateOnly EndDate,
    IEnumerable<PrerequisiteDto>? Prequisites = null,
    IEnumerable<CourseModuleDto>? Modules = null) : IRequest<CourseId>;

public class CreateCourseHandler(ICourseRepository repository)
    : IRequestHandler<CreateCourseCommand, CourseId>
{
    public async Task<CourseId> Handle(
        CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = Course.Create(
            request.InstructorId,
            request.Title,
            request.Description,
            request.SkillLevel,
            request.StartDate,
            request.EndDate);

        if (request.Prequisites is not null)
        {
            foreach (var prerequisite in request.Prequisites)
            {
                course.AddPrerequisite(
                    Prerequisite.Create(course.Id, prerequisite.Description));
            }
        }

        if (request.Modules is not null)
        {
            foreach (var module in request.Modules)
            {
                course.AddModule(
                    CourseModule.Create(
                        course.Id,
                        module.ModuleNumber,
                        module.Title,
                        module.Summary));
            }
        }

        await repository.AddAsync(course);

        return course.Id;
    }
}
