using System.Collections.Generic;
using Triggerity.Definitions;
using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain
{
    [Aggregate]
    public class Company
    {
        public static readonly IDictionary<Currency, Money> MaximumDebit = new Dictionary<Currency, Money> {
            { Currency.EUR, new Money(100, Currency.EUR) },
            { Currency.PLN, new Money(400, Currency.PLN) }
        };

        public CompanyIdentifier Identifier { get; }
        public Money Balance { get; private set; }
        public PersonIdentifier BigBoss { get; }

        public Company(CompanyIdentifier identifier, Money balance, PersonIdentifier bigBoss)
        {
            Identifier = identifier;
            Balance = balance;
            BigBoss = bigBoss;
        }

        public bool CanPay(Billing billing) =>
            Money.AreCurrenciesMatch(billing.Money, Balance) && ((Balance + MaximumDebit[Balance.Currency]) >= billing.Money);

        public void Pay(Billing billing)
        {
            if (!CanPay(billing))
            {
                throw new DomainException($"{Identifier.Id} company cannot pay for the billing");
            }
            Balance -= billing.Money;
        }
    }
}
