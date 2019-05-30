using System.Threading.Tasks;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Repository]
    public interface ITriggerOrderRepository
    {
        Task Save(TriggerOrder triggerOrder);
    }
}
