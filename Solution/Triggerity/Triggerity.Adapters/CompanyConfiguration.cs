using System;
using Triggerity.Domain;

namespace Triggerity.Adapters
{
    internal class CompanyConfiguration : ICompanyConfiguration
    {
        public BillingPreference GetBillingPreference(CompanyIdentifier companyIdentifier)
        {
            var rnd = new Random();
            if (rnd.NextDouble() > 0.5)
            {
                return BillingPreference.BillingPerTrigger;
            }
            return BillingPreference.BillingPerTriggerOrder;
        }
    }
}
