using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands.Executor
{    
    public interface ICommandExecutor
    {
        Task Execute<TCommand>(TCommand command);
    }
}
