using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Builders;

public class ConnectCommandBuilder
{
    private ConnectionFacade? _connectionFacade;
    private string? _address;
    private string? _mode;

    public ConnectCommandBuilder WithConnectionFacade(ConnectionFacade connectionFacade)
    {
        _connectionFacade = connectionFacade;
        return this;
    }

    public ConnectCommandBuilder WithAddress(string address)
    {
        _address = address;
        return this;
    }

    public ConnectCommandBuilder WithMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public ConnectCommand Build()
    {
        return new ConnectCommand(
            _connectionFacade ?? throw new ArgumentNullException(nameof(_connectionFacade)),
            _address ?? throw new ArgumentNullException(nameof(_address)),
            _mode ?? throw new ArgumentNullException(nameof(_mode)));
    }
}