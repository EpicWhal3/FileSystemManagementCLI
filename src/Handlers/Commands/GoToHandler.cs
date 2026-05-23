using Itmo.ObjectOrientedProgramming.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Handlers.Commands;

public class GoToHandler : CommandHandler
{
    private readonly NavigationFacade _navigationFacade;

    public GoToHandler(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "tree")
            return PassToNext(args);

        iterator.MoveNext();
        if (!iterator.HasNext() || iterator.Current != "goto")
            return PassToNext(args);

        iterator.MoveNext();
        var pathHandler = new PathArgumentHandler();
        pathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(pathHandler.Path))
        {
            Console.WriteLine("Path is required for tree goto command.");
            return new CreateCommandResult.FailCreate();
        }

        GoToCommand command = new GoToCommandBuilder()
            .WithNavigationFacade(_navigationFacade)
            .WithPath(pathHandler.Path)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessGoToCommand(command);
    }
}