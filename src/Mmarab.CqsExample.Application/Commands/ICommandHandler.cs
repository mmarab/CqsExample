using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<in TCommand> : ICommandHandler
    {
        Task Handle(TCommand command);
    }
}
