using Itmo.ObjectOrientedProgramming.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.Handlers.Arguments;
using Itmo.ObjectOrientedProgramming.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Handlers.Commands;

public class DeleteFileHandler : CommandHandler
{
    private readonly NavigationFacade _navigationFacade;

    public DeleteFileHandler(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (!iterator.HasNext() || iterator.Current != "file")
            return PassToNext(args);

        iterator.MoveNext();

        if (!iterator.HasNext() || iterator.Current != "delete")
            return PassToNext(args);

        iterator.MoveNext();

        var pathHandler = new PathArgumentHandler();
        pathHandler.Handle(iterator);

        if (string.IsNullOrWhiteSpace(pathHandler.Path))
        {
            Console.WriteLine("Path is required for file delete command.");
            return new CreateCommandResult.FailCreate();
        }

        DeleteFileCommand command = new DeleteFileCommandBuilder()
            .WithNavigationFacade(_navigationFacade)
            .WithPath(pathHandler.Path)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessDeleteFileCommand(command);
    }
}