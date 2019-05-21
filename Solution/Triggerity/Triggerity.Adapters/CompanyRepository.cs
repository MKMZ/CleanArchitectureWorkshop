using System;
using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.Adapters
{
    class CompanyRepository
        : ICompanyRepository
    {
        public Task<Company> GetCompanyById(CompanyIdentifier companyIdentifier)
        {
            return Task.FromResult(new Company(companyIdentifier, new Money(300, Currency.PLN), new PersonIdentifier(Guid.NewGuid())));
        }

        public Task Update(Company company)
        {
            return Task.CompletedTask;
        }
    }
}
