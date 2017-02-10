namespace Mmarab.CqsExample.Application.Commands
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Create<TCommand>();
        void Destroy<TCommand>(TCommand command);
    }
}
