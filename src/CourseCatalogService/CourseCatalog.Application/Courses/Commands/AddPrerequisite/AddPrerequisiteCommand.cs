using CourseCatalog.Contracts.Courses.Responses;
using CourseCatalog.Domain.Courses.ValueObjects;
using MediatR;

namespace CourseCatalog.Application.Courses.Commands.AddPrerequisite;

public record class AddPrerequisiteCommand(
    CourseId CourseId,
    string Description) : IRequest<PrerequisiteResponse>;
