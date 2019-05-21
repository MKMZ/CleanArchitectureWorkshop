using System.Threading.Tasks;

namespace Triggerity.Domain
{
    public interface ITriggerRepository
    {
        Task Save(Trigger trigger);
    }
}
