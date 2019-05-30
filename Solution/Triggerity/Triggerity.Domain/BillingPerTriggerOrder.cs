using System.Collections.Generic;
using System.Linq;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Policy]
    public class BillingPerTriggerOrder : IBillingMethod
    {
        public IList<Billing> CreateBilling(TriggerOrder triggerOrder, Company company)
        {
            var sumValue = triggerOrder
                .Triggers
                .Select(trigger => trigger.Money)
                .Aggregate(Money.Zero(company.Balance.Currency), (acc, money) => acc + money);

            return new List<Billing>
            {
                new Billing(sumValue, company.Identifier)
            };
        }
    }
}
