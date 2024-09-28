using Ardalis.Specification;
using CourseCatalog.Domain.Instructors.ValueObjects;

namespace CourseCatalog.Domain.Courses.Specifications;

public class CoursesByInstructorIdSpecification : Specification<Course>
{
    public CoursesByInstructorIdSpecification(InstructorId instructorId)
    {
        Query.Where(course => course.InstructorId == instructorId);
    }
}
