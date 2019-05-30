using System.Collections.Generic;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Policy]
    public interface IBillingMethod
    {
        IList<Billing> CreateBilling(TriggerOrder triggerOrder, Company company);
    }
}
