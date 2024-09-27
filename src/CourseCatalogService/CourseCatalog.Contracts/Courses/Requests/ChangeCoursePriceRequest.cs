using CourseCatalog.Contracts.Courses.Dtos;

namespace CourseCatalog.Contracts.Courses.Requests;

public record class ChangeCoursePriceRequest(PriceDto NewPrice);
