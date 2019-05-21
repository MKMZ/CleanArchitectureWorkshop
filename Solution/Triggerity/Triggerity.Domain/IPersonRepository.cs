using System.Collections.Generic;
using System.Threading.Tasks;

namespace Triggerity.Domain
{
    public interface IPersonRepository
    {
        Task<IList<PersonIdentifier>> GetPeopleByCompany(CompanyIdentifier companyIdentifier);
    }
}
