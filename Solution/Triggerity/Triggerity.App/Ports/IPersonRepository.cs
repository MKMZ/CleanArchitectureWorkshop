using System.Collections.Generic;
using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.App.Ports
{
    public interface IPersonRepository
    {
        Task<IList<PersonIdentifier>> GetPeopleByCompany(CompanyIdentifier companyIdentifier);
    }
}
