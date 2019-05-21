using System.Collections.Generic;
using System.Linq;

namespace Triggerity.Domain
{
    public class TriggerOrder
    {
        public string Description { get; }
        public IList<Trigger> Triggers { get; private set; }
        public Billing Billing { get; private set; }

        public TriggerOrder(string description, CompanyIdentifier companyIdentifier, Currency currency)
        {
            Description = description;
            Triggers = new List<Trigger>();
            Billing = new Billing(Money.Zero(currency), companyIdentifier);
        }

        public TriggerOrder(string description, IList<Trigger> triggers, Billing billing)
        {
            Description = description;
            Triggers = triggers;
            Billing = billing;
        }

        public void AddTrigger(Trigger trigger)
        {
            Triggers.Add(trigger);
            UpdateBilling();
        }

        private void UpdateBilling()
        {
            Money billingMoney = Money.Zero(Billing.Money.Currency);
            foreach (var trigger in Triggers)
            {
                billingMoney += trigger.Money;
            }
            Billing = new Billing(billingMoney, Billing.CompanyIdentifier);
        }
    }
}
