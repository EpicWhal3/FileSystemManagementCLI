using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Handlers.Flags;

namespace Itmo.ObjectOrientedProgramming.Factories;

public class FlagHandlerFactory : IFlagHandlerFactory
{
    public FlagHandler CreateFlagHandlerChain()
    {
        FlagHandler mode = new ModeFlagHandler();
        FlagHandler depth = new DepthFlagHandler();

        mode.SetNext(depth);
        depth.SetNext(null);
        return mode;
    }
}