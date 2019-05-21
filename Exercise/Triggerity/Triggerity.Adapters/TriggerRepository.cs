using System.Threading.Tasks;
using Triggerity.App.Ports;
using Triggerity.Domain;

namespace Triggerity.Adapters
{
    internal class TriggerRepository
        : ITriggerRepository
    {
        public Task Save(Trigger trigger)
        {
            return Task.CompletedTask;
        }
    }
}
