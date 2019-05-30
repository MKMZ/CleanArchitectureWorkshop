using System.Diagnostics.CodeAnalysis;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [ValueObject]
    [Record, ExcludeFromCodeCoverage]
    public partial class Billing
    {
        public Money Money { get; }
        public CompanyIdentifier CompanyIdentifier { get; }
    }
}
