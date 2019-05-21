using System.Collections.Generic;
using System.Threading.Tasks;

namespace Triggerity.Domain
{
    public interface ITreasuryRepository
    {
        Task<IList<Treasury>> GetTreasuriesByCompany(CompanyIdentifier companyIdentifier);
        Task<Treasury> GetByPersonIdentifier(PersonIdentifier personIdentifier);
        Task Update(Treasury treasury);
    }
}
