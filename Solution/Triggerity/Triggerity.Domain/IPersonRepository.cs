using System.Collections.Generic;
using System.Threading.Tasks;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Repository]
    public interface IPersonRepository
    {
        Task<IList<PersonIdentifier>> GetPeopleByCompany(CompanyIdentifier companyIdentifier);
    }
}
