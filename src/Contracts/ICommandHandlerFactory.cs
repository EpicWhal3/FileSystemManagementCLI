using Itmo.ObjectOrientedProgramming.Handlers.Commands;

namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface ICommandHandlerFactory
{
    public CommandHandler CreateCommandHandlerChain();
}