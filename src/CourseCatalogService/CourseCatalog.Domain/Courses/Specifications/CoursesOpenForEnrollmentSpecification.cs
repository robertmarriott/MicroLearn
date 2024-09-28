using Ardalis.Specification;

namespace CourseCatalog.Domain.Courses.Specifications;

public class CoursesOpenForEnrollmentSpecification : Specification<Course>
{
    public CoursesOpenForEnrollmentSpecification()
    {
        Query.Where(course => course.IsOpenForEnrollment);
    }
}
