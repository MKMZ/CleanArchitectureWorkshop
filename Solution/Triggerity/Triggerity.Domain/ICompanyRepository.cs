using System.Threading.Tasks;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Repository]
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(CompanyIdentifier companyIdentifier);
        Task Update(Company company);
    }
}
