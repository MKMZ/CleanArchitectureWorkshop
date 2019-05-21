using Triggerity.Domain.Exceptions;

namespace Triggerity.Domain
{
    public class Treasury
    {
        public PersonIdentifier PersonIdentifier { get; }
        public Money GivingMoney { get; private set; }
        public Money SpendingMoney { get; private set; }

        public Treasury(PersonIdentifier identifier, Money givingMoney, Money spendingMoney)
        {
            PersonIdentifier = identifier;
            GivingMoney = givingMoney;
            SpendingMoney = spendingMoney;
        }
		
		// TODO
    }
}
