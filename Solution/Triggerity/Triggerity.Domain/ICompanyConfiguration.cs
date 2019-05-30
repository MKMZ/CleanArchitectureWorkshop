using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Repository]
    public interface ICompanyConfiguration
    {
        BillingPreference GetBillingPreference(CompanyIdentifier companyIdentifier);
    }
}
