using System.Diagnostics.CodeAnalysis;

namespace Triggerity.Domain
{
    [Record, ExcludeFromCodeCoverage]
    public partial class Billing
    {
        public Money Money { get; }
        public CompanyIdentifier CompanyIdentifier { get; }
    }
}
