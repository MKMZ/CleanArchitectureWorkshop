using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.Adapters
{
    internal class PersonRepository
        : IPersonRepository
    {
        public Task<IList<PersonIdentifier>> GetPeopleByCompany(CompanyIdentifier companyIdentifier)
        {
            var people = new List<PersonIdentifier>();
            people.Add(new PersonIdentifier(Guid.NewGuid()));
            people.Add(new PersonIdentifier(Guid.NewGuid()));
            return Task.FromResult((IList<PersonIdentifier>) people);
        }
    }
}
