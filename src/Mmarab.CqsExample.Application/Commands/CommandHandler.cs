using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand>
    {
        public async Task Handle(TCommand command)
        {
            await DoHandle(command);
        }

        protected abstract Task DoHandle(TCommand command);
    }
}
