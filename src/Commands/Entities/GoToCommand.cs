using Itmo.ObjectOrientedProgramming.Contracts;
using Itmo.ObjectOrientedProgramming.Facades;

namespace Itmo.ObjectOrientedProgramming.Commands.Entities;

public class GoToCommand : ICommand
{
    private readonly NavigationFacade _navigationFacade;
    private readonly string _path;

    public GoToCommand(NavigationFacade navigationFacade, string path)
    {
        _navigationFacade = navigationFacade;
        _path = path;
    }

    public void Execute()
    {
        _navigationFacade.ChangeDirectory(_path);
    }
}