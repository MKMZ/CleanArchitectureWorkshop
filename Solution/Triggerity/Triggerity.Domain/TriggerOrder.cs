using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Triggerity.Definitions;
using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain
{
    [Aggregate]
    public class TriggerOrder
    {
        public string Description { get; }
        public IImmutableList<Trigger> Triggers { get; private set; }
        public DateTime ScheduledDate { get; private set; }

        public TriggerOrder(string description, CompanyIdentifier companyIdentifier, Currency currency)
        {
            Description = description;
            Triggers = ImmutableList.Create<Trigger>();
            ScheduledDate = DateTime.UtcNow + TimeSpan.FromSeconds(5);
        }

        public TriggerOrder(string description, IList<Trigger> triggers, Billing billing)
        {
            Description = description;
            Triggers = ImmutableList.CreateRange(triggers);
            ScheduledDate = DateTime.UtcNow + TimeSpan.FromSeconds(5);
        }

        public void AddTrigger(Trigger trigger)
        {
            Triggers = Triggers.Add(trigger);
        }
        public void SetScheduledDate(DateTime newDate)
        {
            if (newDate < DateTime.UtcNow)
            {
                throw new DomainException("Scheduled date cannot be earlier than now");
            }
            ScheduledDate = newDate;
        }
    }
}
