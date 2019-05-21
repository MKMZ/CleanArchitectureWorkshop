using System;
using System.Threading.Tasks;
using Triggerity.Definitions;
using Triggerity.Domain;
using Triggerity.Domain.Exceptions;

namespace Triggerity.App.UseCases
{
    internal class GiveTriggerUseCase
        : ICommandHandler<GiveTriggerCommand>
    {
        private readonly ITreasuryRepository _treasuryRepository;
        private readonly ITriggerRepository _triggerRepository;

        public GiveTriggerUseCase(ITreasuryRepository treasuryRepository, ITriggerRepository triggerRepository)
        {
            _treasuryRepository = treasuryRepository;
            _triggerRepository = triggerRepository;
        }

        public async Task Handle(GiveTriggerCommand command)
        {
			// TODO
        }
    }
}
