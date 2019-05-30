using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Aggregate]
    public class Person
    {
        public PersonIdentifier Identifier { get; }
        public CompanyIdentifier CompanyIdentifier { get; }

    }
}
