namespace Mmarab.CqsExample.Application.Commands.Executor
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<TCommand> Create<TCommand>();
        void Destroy<TCommand>(TCommand command);
    }
}
