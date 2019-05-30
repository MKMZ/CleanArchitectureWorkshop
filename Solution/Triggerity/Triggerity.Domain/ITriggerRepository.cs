using System.Threading.Tasks;
using Triggerity.Definitions;

namespace Triggerity.Domain
{
    [Repository]
    public interface ITriggerRepository
    {
        Task Save(Trigger trigger);
    }
}
