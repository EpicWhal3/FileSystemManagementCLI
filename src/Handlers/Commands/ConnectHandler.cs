using Itmo.ObjectOrientedProgramming.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Handlers.Commands;

public class ConnectHandler : CommandHandler
{
    private readonly ConnectionFacade _connectionFacade;

    public ConnectHandler(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (iterator.Current != "connect")
            return PassToNext(args);

        if (!iterator.HasNext())
        {
            Console.WriteLine("Address is required for the connect command.");
            return new CreateCommandResult.FailCreate();
        }

        iterator.MoveNext();

        string address = iterator.Current;

        if (!iterator.HasNext())
        {
            Console.WriteLine("Mode is required.");
            return new CreateCommandResult.FailCreate();
        }

        iterator.MoveNext();

        if (!iterator.HasNext() || iterator.Current != "-m")
        {
            Console.WriteLine("Mode flag is required for the connect command.");
            return new CreateCommandResult.FailCreate();
        }

        string mode = "local";

        ConnectCommand command = new ConnectCommandBuilder()
            .WithConnectionFacade(_connectionFacade)
            .WithAddress(address)
            .WithMode(mode)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessConnectCommand(command);
    }
}