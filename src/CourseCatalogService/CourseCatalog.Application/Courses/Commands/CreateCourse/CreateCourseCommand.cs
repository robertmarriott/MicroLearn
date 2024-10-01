using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses.Enums;
using CourseCatalog.Domain.Courses.ValueObjects;
using CourseCatalog.Domain.Instructors.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.CreateCourse;

public record class CreateCourseCommand(
    InstructorId InstructorId,
    string Title,
    SkillLevel SkillLevel,
    Price Price,
    DateTime StartDate,
    DateTime EndDate) : IRequest<CourseResponse>;
