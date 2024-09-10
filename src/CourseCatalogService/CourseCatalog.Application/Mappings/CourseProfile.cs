namespace CourseCatalog.Application.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(
                dest => dest.SkillLevel,
                opt => opt.MapFrom(src => src.SkillLevel.ToString()))
            .ForMember(
                dest => dest.Price,
                opt => opt.MapFrom(
                    src => new PriceDto(
                        src.Price.Amount,
                        src.Price.Currency.ToString())))
            .ForMember(
                dest => dest.Prerequisites,
                opt => opt.MapFrom(
                    src => src.Prerequisites.Select(
                        p => new PrerequisiteDto(p.Description))));
    }
}
