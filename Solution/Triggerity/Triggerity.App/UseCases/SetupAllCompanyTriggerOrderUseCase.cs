using System;
using System.Linq;
using System.Threading.Tasks;
using Triggerity.Definitions;
using Triggerity.Domain;
using Triggerity.Domain.Exceptions;

namespace Triggerity.App.UseCases
{
    internal class SetupAllCompanyTriggerOrderUseCase
        : ICommandHandler<SetupAllCompanyTriggerOrderCommand>
    {
        private readonly ITreasuryRepository _treasuryRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITriggerOrderRepository _triggerOrderRepository;

        public SetupAllCompanyTriggerOrderUseCase(ITreasuryRepository treasuryRepository, ICompanyRepository companyRepository, ITriggerOrderRepository triggerOrderRepository)
        {
            _treasuryRepository = treasuryRepository;
            _companyRepository = companyRepository;
            _triggerOrderRepository = triggerOrderRepository;
        }

        public async Task Handle(SetupAllCompanyTriggerOrderCommand command)
        {
            var companyId = new CompanyIdentifier(command.CompanyId);
            var currency = (Currency)Enum.Parse(typeof(Currency), command.Currency);
            var treasuries = await _treasuryRepository.GetTreasuriesByCompany(companyId);
            var company = await _companyRepository.GetCompanyById(companyId);
            var triggerOrder = new TriggerOrder(
                description: command.Description, 
                companyIdentifier: companyId, 
                currency: currency);
            var moneyPerPerson = new Money(Decimal.Round(command.Amount / treasuries.Count, 2), currency);

            foreach (var treasury in treasuries)
            {
                var trigger = new Trigger(
                    Description: $"Part of \"{command.Description}\" order",
                    Money: moneyPerPerson,
                    Giver: company.BigBoss,
                    Receiver: treasury.PersonIdentifier,
                    TreasuryMoneyType.Giving);
                triggerOrder.AddTrigger(trigger);
                treasury.ReceiveTrigger(trigger);
            }
            var billingStrategy = new BillingPerTriggerOrder();
            var billing = billingStrategy.CreateBilling(triggerOrder, company).First();

            if (!company.CanPay(billing))
            {
                throw new DomainException($"{company.Identifier.Id} cannot pay for trigger order");
            }
            company.Pay(billing);

            await _companyRepository.Update(company);
            await _triggerOrderRepository.Save(triggerOrder);
            await _treasuryRepository.UpdateMultiple(treasuries);
        }
    }
}
