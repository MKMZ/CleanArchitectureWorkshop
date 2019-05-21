using System;
using System.Threading.Tasks;
using Triggerity.App.Ports;
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
            var giverId = new PersonIdentifier(command.GiverId);
            var receiverId = new PersonIdentifier(command.ReceiverId);
            var giverTreasury = await _treasuryRepository.GetByPersonIdentifier(giverId);
            var receiverTreasury = await _treasuryRepository.GetByPersonIdentifier(receiverId);

            var trigger = new Trigger(
                Description: command.Description,
                Money: new Money(command.Amount, (Currency)Enum.Parse(typeof(Currency), command.Currency)),
                Giver: giverId,
                Receiver: receiverId,
                MoneyType: (TreasuryMoneyType)Enum.Parse(typeof(TreasuryMoneyType), command.MoneyType));

            if (!giverTreasury.CanPayTrigger(trigger))
            {
                throw new DomainException($"{giverId.Id} cannot pay trigger");
            }
            giverTreasury.PayTrigger(trigger);
            receiverTreasury.ReceiveTrigger(trigger);

            await _treasuryRepository.Update(giverTreasury);
            await _treasuryRepository.Update(receiverTreasury);
            await _triggerRepository.Save(trigger);
        }
    }
}
