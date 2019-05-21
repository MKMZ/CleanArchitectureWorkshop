using System.Collections.Generic;
using System.Linq;

namespace Triggerity.Domain
{
    public class TriggerOrder
    {
        public string Description { get; }
        public IList<Trigger> Triggers { get; private set; }
        public Billing Billing { get; private set; }

        public TriggerOrder(string description, CompanyIdentifier companyIdentifier, Currency currency)
        {
            Description = description;
            Triggers = new List<Trigger>();
            Billing = new Billing(Money.Zero(currency), companyIdentifier);
        }

        public TriggerOrder(string description, IList<Trigger> triggers, Billing billing)
        {
            Description = description;
            Triggers = triggers;
            Billing = billing;
        }
		
		// TODO
    }
}
