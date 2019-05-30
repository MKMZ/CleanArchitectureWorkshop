using System.Linq;
using System.Collections.Generic;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Policy]
    public class BillingPerTrigger : IBillingMethod
    {
        public IList<Billing> CreateBilling(TriggerOrder triggerOrder, Company company)
        {
            return triggerOrder
                .Triggers
                .Select(trigger => new Billing(trigger.Money, company.Identifier))
                .ToList();
        }
    }
}
