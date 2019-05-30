using System.Diagnostics.CodeAnalysis;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [ValueObject]
    [Record, ExcludeFromCodeCoverage]
    public partial class Trigger
    {
        public string Description { get; }
        public Money Money { get; }
        public PersonIdentifier Giver { get; }
        public PersonIdentifier Receiver { get; }
        public TreasuryMoneyType MoneyType { get; }
    }
}
