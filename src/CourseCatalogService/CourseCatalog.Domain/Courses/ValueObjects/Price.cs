using CourseCatalog.Domain.Common.Base;
using CourseCatalog.Domain.Courses.Enums;

namespace CourseCatalog.Domain.Courses.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    private Price(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price Create(decimal amount, Currency currency)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(amount, nameof(amount));

        return new Price(amount, currency);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}
