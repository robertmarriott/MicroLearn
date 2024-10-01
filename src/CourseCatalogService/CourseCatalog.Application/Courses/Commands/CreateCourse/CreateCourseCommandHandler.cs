using AutoMapper;
using CourseCatalog.Application.Common.Interfaces;
using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommandHandler(
    ICourseRepository courseRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IRequestHandler<CreateCourseCommand, CourseResponse>
{
    public async Task<CourseResponse> Handle(
        CreateCourseCommand request,
        CancellationToken cancellationToken)
    {
        var course = Course.Create(
            request.InstructorId,
            request.Title,
            request.SkillLevel,
            request.Price,
            request.StartDate,
            request.EndDate);

        await courseRepository.AddAsync(course);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<CourseResponse>(course);
    }
}
