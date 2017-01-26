using Autofac;
using Mmarab.CqsExample.Application.Commands;

namespace Mmarab.CqsExample.Configuration.Factories
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly IComponentContext _context;

        public CommandHandlerFactory(IComponentContext context)
        {
            _context = context;
        }

        public ICommandHandler<TCommand> Create<TCommand>()
        {
            return _context.Resolve<ICommandHandler<TCommand>>();
        }

        public void Destroy<TCommand>(TCommand command)
        {

        }
    }
}