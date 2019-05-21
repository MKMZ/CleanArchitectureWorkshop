using System.Threading.Tasks;

namespace Triggerity.Domain
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(CompanyIdentifier companyIdentifier);
        Task Update(Company company);
    }
}
