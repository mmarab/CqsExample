using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands.Executor
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandExecutor(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public async Task Execute<TCommand>(TCommand command)
        {
            var handler = _commandHandlerFactory.Create<TCommand>();

            try
            {
                await handler.Handle(command);
            }
            finally
            {
                _commandHandlerFactory.Destroy(handler);
            }
        }
    }
}
