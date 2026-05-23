using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Builders;

public class DeleteFileCommandBuilder
{
    private NavigationFacade? _navigationFacade;
    private string? _path;

    public DeleteFileCommandBuilder WithNavigationFacade(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
        return this;
    }

    public DeleteFileCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public DeleteFileCommand Build()
    {
        return new DeleteFileCommand(
            _navigationFacade ?? throw new ArgumentNullException(nameof(_navigationFacade)),
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}