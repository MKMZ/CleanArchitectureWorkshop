using Triggerity.Definitions;
using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain
{
    [Factory]
    public interface IBillingMethodSelection
    {
        IBillingMethod GetBillingMethodFor(Company company);
    }

    public class BillingMethodSelection
    {
        private readonly ICompanyConfiguration _companyConfiguration;

        public BillingMethodSelection(ICompanyConfiguration companyConfiguration)
        {
            _companyConfiguration = companyConfiguration;
        }

        public IBillingMethod GetBillingMethodFor(Company company)
        {
            var preference = _companyConfiguration.GetBillingPreference(company.Identifier);
            switch (preference)
            {
                case BillingPreference.BillingPerTrigger:
                    return new BillingPerTrigger();
                case BillingPreference.BillingPerTriggerOrder:
                    return new BillingPerTriggerOrder();
                default:
                    throw new DomainException($"Unknown Billing Preference: {preference}");
            }
        }
    }
}
