using Triggerity.Definitions;
using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain
{
    [Aggregate]
    public class Treasury
    {
        public PersonIdentifier PersonIdentifier { get; }
        public Money GivingMoney { get; private set; }
        public Money SpendingMoney { get; private set; }

        public Treasury(PersonIdentifier identifier, Money givingMoney, Money spendingMoney)
        {
            PersonIdentifier = identifier;
            GivingMoney = givingMoney;
            SpendingMoney = spendingMoney;
        }

        public bool CanPayTrigger(Trigger trigger)
        {
            switch (trigger.MoneyType)
            {
                case TreasuryMoneyType.Giving:
                    return GivingMoney >= trigger.Money;
                case TreasuryMoneyType.Spending:
                    return SpendingMoney >= trigger.Money;
                default:
                    throw new DomainException("Unsupported treasury type");
            }
        }

        public void PayTrigger(Trigger trigger)
        {
            if (!CanPayTrigger(trigger)) {
                throw new DomainException("Cannot pay trigger");
            }
            PerformTriggerPayment(trigger);
        }

        public void ReceiveTrigger(Trigger trigger)
        {
            SpendingMoney += trigger.Money;
        }

        private void PerformTriggerPayment(Trigger trigger)
        {
            switch (trigger.MoneyType)
            {
                case TreasuryMoneyType.Giving:
                    GivingMoney -= trigger.Money;
                    break;
                case TreasuryMoneyType.Spending:
                    SpendingMoney -= trigger.Money;
                    break;
                default:
                    throw new DomainException("Unsupported treasury type");
            }
        }
    }
}
