using Itmo.ObjectOrientedProgramming.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.Factories;
using Itmo.ObjectOrientedProgramming.Handlers.Flags;
using Itmo.ObjectOrientedProgramming.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Handlers.Commands;

public class ListHandler : CommandHandler
{
    private readonly ReadFacade _readFacade;

    public ListHandler(ReadFacade navigator)
    {
        _readFacade = navigator;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "tree")
            return PassToNext(args);

        iterator.MoveNext();

        if (iterator.Current != "list")
            return PassToNext(args);

        iterator.MoveNext();

        int depth = 1;

        var flagHandlerFactory = new FlagHandlerFactory();
        FlagHandler flagHandler = flagHandlerFactory.CreateFlagHandlerChain();

        FlagParseResult flagResult = flagHandler.Handle(iterator);

        switch (flagResult)
        {
            case FlagParseResult.SuccessfulParseDepth depthResult:
                depth = depthResult.Depth;
                break;

            case FlagParseResult.FailParse:
                Console.WriteLine("Invalid flag or value.");
                return new CreateCommandResult.FailCreate();
        }

        var visitor = new ConsoleVisitor();

        ListCommand command = new ListCommandBuilder()
            .WithVisitor(visitor)
            .WithReadFacade(_readFacade)
            .WithDepth(depth)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessListCommand(command);
    }
}