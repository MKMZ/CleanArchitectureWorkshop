using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.Adapters
{
    internal class TreasuryRepository
        : ITreasuryRepository
    {
        public Task<Treasury> GetByPersonIdentifier(PersonIdentifier personIdentifier)
        {
            return Task.FromResult(
                new Treasury(new PersonIdentifier(Guid.NewGuid()), new Money(100, Currency.PLN), new Money(100, Currency.PLN))
            );
        }

        public Task<IList<Treasury>> GetTreasuriesByCompany(CompanyIdentifier companyIdentifier)
        {
            var treasuries = new List<Treasury>();
            treasuries.Add(new Treasury(new PersonIdentifier(Guid.NewGuid()), new Money(100, Currency.PLN), new Money(100, Currency.PLN)));
            treasuries.Add(new Treasury(new PersonIdentifier(Guid.NewGuid()), new Money(100, Currency.PLN), new Money(100, Currency.PLN)));
            return Task.FromResult((IList<Treasury>) treasuries);
        }

        public Task Update(Treasury treasury)
        {
            return Task.CompletedTask;
        }
    }
}
