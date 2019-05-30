using System.Threading.Tasks;

namespace Triggerity.Domain
{
    [Repository]
    public interface ITriggerOrderRepository
    {
        Task Save(TriggerOrder triggerOrder);
    }
}
