using System;
using System.Diagnostics.CodeAnalysis;


namespace Triggerity.Domain
{
    [Record, ExcludeFromCodeCoverage]
    public partial class PersonIdentifier
    {
        public Guid Id { get; }
    }
}
