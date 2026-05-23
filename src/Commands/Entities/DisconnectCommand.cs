using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class DisconnectCommand : ICommand
{
    private readonly ConnectionFacade _connectionFacade;

    public DisconnectCommand(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
    }

    public void Execute()
    {
        _connectionFacade.Disconnect();
    }
}