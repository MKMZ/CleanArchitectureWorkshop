using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.App.Ports
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(CompanyIdentifier companyIdentifier);
        Task Update(Company company);
    }
}
