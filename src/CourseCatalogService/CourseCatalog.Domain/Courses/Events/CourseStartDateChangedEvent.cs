﻿using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.ValueObjects;

namespace CourseCatalog.Domain.Courses.Events;

public record class CourseStartDateChangedEvent(
    CourseId CourseId,
    DateTime NewStartDate) : IDomainEvent;
