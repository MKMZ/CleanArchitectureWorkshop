using System.Threading.Tasks;

namespace Triggerity.Definitions
{
    public interface ICommandHandler<T>
        where T : ICommand
    {
        Task Handle(T command);
    }
}
