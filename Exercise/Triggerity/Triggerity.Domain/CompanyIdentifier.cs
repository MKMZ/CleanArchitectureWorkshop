using System;
using System.Diagnostics.CodeAnalysis;

namespace Triggerity.Domain
{
    [Record, ExcludeFromCodeCoverage]
    public partial class CompanyIdentifier
    {
        public Guid Id { get; }
    }
}
