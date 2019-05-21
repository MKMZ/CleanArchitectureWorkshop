using System.Threading.Tasks;
using Triggerity.Domain;

namespace Triggerity.App.Ports
{
    public interface ITriggerRepository
    {
        Task Save(Trigger trigger);
    }
}
