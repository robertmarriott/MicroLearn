﻿namespace CourseCatalog.Contracts.Common;

public record class CourseDto(
    Guid Id,
    Guid InstructorId,
    string Title,
    string SkillLevel,
    DateOnly StartDate,
    DateOnly EndDate,
    PriceDto Price,
    List<PrerequisiteDto> Prerequisites);
