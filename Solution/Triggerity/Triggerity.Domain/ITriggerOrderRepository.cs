using System.Threading.Tasks;

namespace Triggerity.Domain
{
    public interface ITriggerOrderRepository
    {
        Task Save(TriggerOrder triggerOrder);
    }
}
