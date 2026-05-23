using Itmo.ObjectOrientedProgramming.Handlers.Flags;

namespace Itmo.ObjectOrientedProgramming.Contracts;

public interface IFlagHandlerFactory
{
    FlagHandler CreateFlagHandlerChain();
}