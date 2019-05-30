using System.Diagnostics.CodeAnalysis;
using Triggerity.Definitions;
using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain
{
    [ValueObject]
    [Record, ExcludeFromCodeCoverage]
    public partial class Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public static Money Zero(Currency currency) =>
            new Money(0, currency);

        public static Money operator +(Money a, Money b)
        {
            ValidCurrencies(a, b);
            return new Money(a.Amount + b.Amount, a.Currency);
        }

        public static Money operator -(Money a, Money b)
        {
            ValidCurrencies(a, b);
            return new Money(a.Amount - b.Amount, a.Currency);
        }

        public static Money operator *(Money a, Money b)
        {
            ValidCurrencies(a, b);
            return new Money(a.Amount * b.Amount, a.Currency);
        }

        public static Money operator /(Money a, Money b)
        {
            ValidCurrencies(a, b);
            return new Money(a.Amount / b.Amount, a.Currency);
        }

        public static bool operator >=(Money a, Money b)
        {
            ValidCurrencies(a, b);
            return a.Amount >= b.Amount;
        }
        public static bool operator <=(Money a, Money b)
        {
            ValidCurrencies(a, b);
            return a.Amount <= b.Amount;
        }

        public static bool AreCurrenciesMatch(Money a, Money b)
        {
            return (a.Currency == b.Currency);
        }

        public static void ValidCurrencies(Money a, Money b)
        {
            if (!AreCurrenciesMatch(a, b))
            {
                throw new DomainException("Currencies must be equal to perform operation");
            }
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}
