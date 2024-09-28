using Ardalis.Specification;

namespace CourseCatalog.Domain.Courses.Specifications;

public class CoursesForFreeSpecification : Specification<Course>
{
    public CoursesForFreeSpecification()
    {
        Query.Where(course => course.IsFree);
    }
}
