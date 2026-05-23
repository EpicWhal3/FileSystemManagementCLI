using Itmo.ObjectOrientedProgramming.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Handlers.Commands;

public class RenameFileHandler : CommandHandler
{
    private readonly NavigationFacade _navigationFacade;

    public RenameFileHandler(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "file")
            return PassToNext(args);

        iterator.MoveNext();

        if (!iterator.HasNext() || iterator.Current != "rename")
            return PassToNext(args);

        iterator.MoveNext();

        var pathHandler = new PathArgumentHandler();
        pathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(pathHandler.Path))
        {
            Console.WriteLine("Path is required for file rename command.");
            return new CreateCommandResult.FailCreate();
        }

        if (!iterator.HasNext())
        {
            Console.WriteLine("New name is required for file rename command.");
            return new CreateCommandResult.FailCreate();
        }

        iterator.MoveNext();

        string newName = iterator.Current;

        if (string.IsNullOrWhiteSpace(newName))
        {
            Console.WriteLine("New name cannot be empty.");
            return new CreateCommandResult.FailCreate();
        }

        RenameFileCommand command = new RenameFileCommandBuilder()
            .WithNavigationFacade(_navigationFacade)
            .WithPath(pathHandler.Path)
            .WithNewName(newName)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessRenameFileCommand(command);
    }
}