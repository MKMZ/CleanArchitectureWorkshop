using System.Collections.Generic;
using System.Threading.Tasks;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Repository]
    public interface ITreasuryRepository
    {
        Task<IList<Treasury>> GetTreasuriesByCompany(CompanyIdentifier companyIdentifier);
        Task<Treasury> GetByPersonIdentifier(PersonIdentifier personIdentifier);
        Task Update(Treasury treasury);
        Task UpdateMultiple(IList<Treasury> treasuries);
    }
}
