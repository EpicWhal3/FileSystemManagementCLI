using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Builders;

public class ShowFileCommandBuilder
{
    private ReadFacade? _readFacade;
    private string? _path;
    private string? _mode;

    public ShowFileCommandBuilder WithReadFacade(ReadFacade readFacade)
    {
        _readFacade = readFacade;
        return this;
    }

    public ShowFileCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public ShowFileCommandBuilder WithMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public ShowFileContentCommand Build()
    {
        return new ShowFileContentCommand(
            _readFacade ?? throw new ArgumentNullException(nameof(_readFacade)),
            _path ?? throw new ArgumentNullException(nameof(_path)),
            _mode ?? "console");
    }
}