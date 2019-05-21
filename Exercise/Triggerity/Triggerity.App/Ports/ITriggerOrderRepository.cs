using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.App.Ports
{
    public interface ITriggerOrderRepository
    {
        Task Save(TriggerOrder triggerOrder);
    }
}
