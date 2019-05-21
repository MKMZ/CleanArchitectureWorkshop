using System;
using System.Diagnostics.CodeAnalysis;
using Triggerity.Definitions;

namespace Triggerity.App.UseCases
{
    [Record, ExcludeFromCodeCoverage]
    public partial class SetupAllCompanyTriggerOrderCommand
        : ICommand
    {
        public string Description { get; }
        public Guid CompanyId { get; }
        public decimal Amount { get; }
        public string Currency { get; }
    }
}
