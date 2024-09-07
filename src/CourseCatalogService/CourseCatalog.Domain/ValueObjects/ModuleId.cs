namespace CourseCatalog.Domain.ValueObjects;

public readonly record struct ModuleId(Guid Value)
{
    public ModuleId() : this(Guid.NewGuid()) { }
}
