using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands
{    
    public interface ICommandExecutor
    {
        Task Execute<TCommand>(TCommand command);
    }
}
