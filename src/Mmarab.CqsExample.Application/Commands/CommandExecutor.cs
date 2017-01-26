using System;
using System.Threading.Tasks;

namespace Mmarab.CqsExample.Application.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;
        private readonly ILogger _logger;

        public CommandExecutor(ICommandHandlerFactory commandHandlerFactory, ILogger logger)
        {
            _commandHandlerFactory = commandHandlerFactory;
            _logger = logger;
        }

        public async Task Execute<TCommand>(TCommand command)
        {
            var handler = _commandHandlerFactory.Create<TCommand>();

            try
            {
                await handler.Handle(command);
            }
            catch (Exception ex)
            {
                await _logger.Error(handler.GetType().ToString(), ex);
            }
            finally
            {
                _commandHandlerFactory.Destroy(handler);
            }
        }
    }
}
