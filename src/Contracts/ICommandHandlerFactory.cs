using Itmo.ObjectOrientedProgramming.Handlers.Commands;

namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface ICommandHandlerFactory
{
    CommandHandler CreateCommandHandlerChain();
}