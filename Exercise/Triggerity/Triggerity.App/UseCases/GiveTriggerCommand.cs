using System;
using System.Diagnostics.CodeAnalysis;
using Triggerity.Definitions;

namespace Triggerity.App.UseCases
{
    [Record, ExcludeFromCodeCoverage]
    public partial class GiveTriggerCommand : ICommand
    {
        public Guid GiverId { get; }
        public Guid ReceiverId { get; }
        public string MoneyType { get; }
        public decimal Amount { get; }
        public string Currency { get; }
        public string Description { get; }
    }
}
