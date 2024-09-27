using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;
using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseCreatedEvent(
    InstructorId InstructorId,
    CourseId CourseId) : DomainEvent;
