using Itmo.ObjectOrientedProgramming.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Entities;
using Itmo.ObjectOrientedProgramming.Facades;
using Itmo.ObjectOrientedProgramming.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Handlers.Commands;

public class DisconnectHandler : CommandHandler
{
    private readonly ConnectionFacade _connectionFacade;

    public DisconnectHandler(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
    }

    public override CreateCommandResult Handle(string[] args)
    {
        var iterator = new CommandIterator(args);

        if (iterator.Current != "disconnect")
            return PassToNext(args);

        DisconnectCommand command = new DisconnectCommandBuilder()
            .WithConnectionFacade(_connectionFacade)
            .Build();

        command.Execute();
        return new CreateCommandResult.SuccessDisconnectCommand(command);
    }
}