using Itmo.ObjectOrientedProgramming.Commands.Entities;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Builders;

public class GoToCommandBuilder
{
    private NavigationFacade? _navigationFacade;
    private string? _path;

    public GoToCommandBuilder WithNavigationFacade(NavigationFacade navigationFacade)
    {
        _navigationFacade = navigationFacade;
        return this;
    }

    public GoToCommandBuilder WithPath(string path)
    {
        _path = path;
        return this;
    }

    public GoToCommand Build()
    {
        return new GoToCommand(
            _navigationFacade ?? throw new ArgumentNullException(nameof(_navigationFacade)),
            _path ?? throw new ArgumentNullException(nameof(_path)));
    }
}