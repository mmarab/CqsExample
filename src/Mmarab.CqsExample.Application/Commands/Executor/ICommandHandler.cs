using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands.Executor
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<in TCommand> : ICommandHandler
    {
        Task Handle(TCommand command);
    }
}
