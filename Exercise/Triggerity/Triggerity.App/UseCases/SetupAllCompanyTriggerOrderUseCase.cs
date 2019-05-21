using System;
using System.Threading.Tasks;
using Triggerity.App.Ports;
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
			// TODO
        }
    }
}
