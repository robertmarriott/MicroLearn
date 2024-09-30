using Ardalis.Specification;

namespace CourseCatalog.Domain.Courses.Specifications;

public class FreeCoursesSpecification : Specification<Course>
{
    public FreeCoursesSpecification()
    {
        Query.Where(course => course.IsFree);
    }
}
