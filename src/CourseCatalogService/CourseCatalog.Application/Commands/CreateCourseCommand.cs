﻿namespace CourseCatalog.Application.Commands;

public record class CreateCourseCommand(
    InstructorId InstructorId,
    string Title,
    SkillLevel SkillLevel,
    DateOnly StartDate,
    DateOnly EndDate,
    Price Price) : IRequest<CourseId>;

public class CreateCourseHandler(ICourseRepository courseRepository)
    : IRequestHandler<CreateCourseCommand, CourseId>
{
    public async Task<CourseId> Handle(
        CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = Course.Create(
            request.InstructorId,
            request.Title,
            request.SkillLevel,
            request.StartDate,
            request.EndDate,
            request.Price);

        await courseRepository.AddAsync(course);

        return course.Id;
    }
}
