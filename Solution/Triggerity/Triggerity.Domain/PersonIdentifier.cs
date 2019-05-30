using System;
using System.Diagnostics.CodeAnalysis;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [ValueObject]
    [Record, ExcludeFromCodeCoverage]
    public partial class PersonIdentifier
    {
        public Guid Id { get; }
    }
}
