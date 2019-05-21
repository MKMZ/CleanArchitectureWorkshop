using System.Collections.Generic;
using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.App.Ports
{
    public interface ITreasuryRepository
    {
        Task<IList<Treasury>> GetTreasuriesByCompany(CompanyIdentifier companyIdentifier);
        Task<Treasury> GetByPersonIdentifier(PersonIdentifier personIdentifier);
        Task Update(Treasury treasury);
    }
}
